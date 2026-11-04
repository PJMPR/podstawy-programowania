document.addEventListener('DOMContentLoaded', () => {
    const codeBlocks = Array.from(document.querySelectorAll('.material-content pre > code'))
        .filter((code) => code.classList.contains('language-csharp') || code.closest('.language-csharp'));
    const focusView = createFocusView();

    codeBlocks.forEach((code, index) => {
        const pre = code.parentElement;
        const wrapper = document.createElement('div');
        const actions = document.createElement('div');
        const copyButton = document.createElement('button');
        const focusButton = document.createElement('button');
        const result = getExampleResult(code);

        wrapper.className = 'code-block';
        wrapper.dataset.language = getLanguageLabel(code);
        pre.parentNode.insertBefore(wrapper, pre);
        wrapper.appendChild(pre);
        createCodeTabs(wrapper, pre, result, `fragment-${index + 1}`);

        actions.className = 'code-actions';
        wrapper.appendChild(actions);

        copyButton.type = 'button';
        copyButton.className = 'code-action-btn copy-code-btn';
        copyButton.textContent = 'Kopiuj';
        copyButton.setAttribute('aria-label', 'Kopiuj kod do schowka');
        actions.appendChild(copyButton);

        focusButton.type = 'button';
        focusButton.className = 'code-action-btn focus-code-btn';
        focusButton.textContent = 'Powiększ';
        focusButton.setAttribute('aria-label', `Powiększ fragment kodu numer ${index + 1}`);
        actions.appendChild(focusButton);

        copyButton.addEventListener('click', async () => {
            try {
                await copyText(code.textContent);
                showStatus(copyButton, 'Skopiowano', 'is-copied');
            } catch (error) {
                showStatus(copyButton, 'Błąd kopiowania', 'is-error');
            }
        });

        focusButton.addEventListener('click', () => {
            openFocusView(focusView, code, result, focusButton, index + 1);
        });
    });

    setupDialogues(focusView);
});

function getLanguageLabel(code) {
    const languageOwner = code.closest('[class*="language-"]') ?? code;
    const languageClass = Array.from(languageOwner.classList)
        .find((className) => className.startsWith('language-'));

    if (!languageClass) {
        return 'KOD';
    }

    const language = languageClass.replace('language-', '').toLowerCase();
    const labels = { csharp: 'C#', cs: 'C#' };
    return labels[language] ?? language.toUpperCase();
}

function getExampleResult(code) {
    let current = code.parentElement;

    while (current && current.classList.contains('highlight')) {
        current = current.parentElement;
    }

    while (current && current !== document.body) {
        let sibling = current.nextSibling;

        while (sibling && sibling.nodeType === Node.TEXT_NODE && !sibling.textContent.trim()) {
            sibling = sibling.nextSibling;
        }

        if (sibling?.nodeType === Node.COMMENT_NODE) {
            const comment = sibling.textContent.trim();
            if (comment.startsWith('code-result:')) {
                return comment.replace(/^code-result:\s*/, '').trim();
            }
        }

        current = current.parentElement;
    }

    return 'Ten fragment przedstawia definicję lub część programu. Nie generuje samodzielnego wyniku.';
}

function createCodeTabs(container, codePanel, result, idPrefix) {
    const tabs = document.createElement('div');
    const codeTab = document.createElement('button');
    const resultTab = document.createElement('button');
    const resultPanel = document.createElement('pre');
    const resultCode = document.createElement('code');

    tabs.className = 'code-tabs';
    tabs.setAttribute('role', 'tablist');
    tabs.setAttribute('aria-label', 'Kod i wynik przykładu');

    codeTab.type = 'button';
    codeTab.className = 'code-tab is-active';
    codeTab.id = `${idPrefix}-code-tab`;
    codeTab.textContent = 'Kod';
    codeTab.setAttribute('role', 'tab');
    codeTab.setAttribute('aria-selected', 'true');

    resultTab.type = 'button';
    resultTab.className = 'code-tab';
    resultTab.id = `${idPrefix}-result-tab`;
    resultTab.textContent = 'Wynik';
    resultTab.setAttribute('role', 'tab');
    resultTab.setAttribute('aria-selected', 'false');

    codePanel.classList.add('code-tab-panel');
    codePanel.id = `${idPrefix}-code-panel`;
    codePanel.setAttribute('role', 'tabpanel');
    codePanel.setAttribute('aria-labelledby', codeTab.id);
    codeTab.setAttribute('aria-controls', codePanel.id);

    resultPanel.className = 'code-tab-panel code-result-panel';
    resultPanel.id = `${idPrefix}-result-panel`;
    resultPanel.hidden = true;
    resultPanel.setAttribute('role', 'tabpanel');
    resultPanel.setAttribute('aria-labelledby', resultTab.id);
    resultTab.setAttribute('aria-controls', resultPanel.id);
    resultCode.textContent = result;
    resultPanel.appendChild(resultCode);

    tabs.append(codeTab, resultTab);
    container.insertBefore(tabs, codePanel);
    container.appendChild(resultPanel);

    const selectTab = (showResult) => {
        codeTab.classList.toggle('is-active', !showResult);
        resultTab.classList.toggle('is-active', showResult);
        codeTab.setAttribute('aria-selected', String(!showResult));
        resultTab.setAttribute('aria-selected', String(showResult));
        codePanel.hidden = showResult;
        resultPanel.hidden = !showResult;
    };

    codeTab.addEventListener('click', () => selectTab(false));
    resultTab.addEventListener('click', () => selectTab(true));
}

function setupDialogues(focusView) {
    const quotes = document.querySelectorAll('.material-content blockquote');
    let dialogueNumber = 0;

    quotes.forEach((quote) => {
        const lines = Array.from(quote.querySelectorAll('p'));
        const hasMacius = lines.some((line) => line.textContent.trim().startsWith('Maciuś:'));
        const hasJan = lines.some((line) => line.textContent.trim().startsWith('Jan:'));

        if (!hasMacius || !hasJan) {
            return;
        }

        dialogueNumber += 1;
        quote.classList.add('dialogue-card');
        quote.setAttribute('aria-label', `Rozmowa Maciusia z Janem, dialog ${dialogueNumber}`);

        lines.forEach((line) => {
            const text = line.textContent.trim();
            line.classList.add('dialogue-line');

            if (text.startsWith('Maciuś:')) {
                line.classList.add('dialogue-junior');
                line.setAttribute('data-avatar', 'M');
            } else if (text.startsWith('Jan:')) {
                line.classList.add('dialogue-senior');
                line.setAttribute('data-avatar', 'J');
            }
        });

        const button = document.createElement('button');
        button.type = 'button';
        button.className = 'dialogue-expand-btn';
        button.textContent = 'Powiększ';
        button.setAttribute('aria-label', `Powiększ dialog ${dialogueNumber}`);
        quote.appendChild(button);

        button.addEventListener('click', () => {
            openDialogueView(focusView, quote, button, dialogueNumber);
        });
    });
}

function createFocusView() {
    const overlay = document.createElement('div');
    const dialog = document.createElement('section');
    const header = document.createElement('header');
    const title = document.createElement('h2');
    const closeButton = document.createElement('button');
    const codeContainer = document.createElement('div');

    overlay.className = 'code-focus-overlay';
    overlay.hidden = true;
    dialog.className = 'code-focus-dialog';
    dialog.setAttribute('role', 'dialog');
    dialog.setAttribute('aria-modal', 'true');
    dialog.setAttribute('aria-labelledby', 'code-focus-title');
    header.className = 'code-focus-header';
    title.id = 'code-focus-title';
    title.textContent = 'Kod do analizy';
    closeButton.type = 'button';
    closeButton.className = 'code-focus-close';
    closeButton.textContent = 'Zamknij';
    closeButton.setAttribute('aria-label', 'Zamknij widok kodu');
    codeContainer.className = 'code-focus-content';

    header.appendChild(title);
    header.appendChild(closeButton);
    dialog.appendChild(header);
    dialog.appendChild(codeContainer);
    overlay.appendChild(dialog);
    document.body.appendChild(overlay);

    const focusView = { overlay, title, closeButton, codeContainer, returnFocus: null };
    closeButton.addEventListener('click', () => closeFocusView(focusView));
    overlay.addEventListener('click', (event) => {
        if (event.target === overlay) {
            closeFocusView(focusView);
        }
    });
    document.addEventListener('keydown', (event) => {
        if (event.key === 'Escape' && !overlay.hidden) {
            closeFocusView(focusView);
        }
    });

    return focusView;
}

function openFocusView(focusView, code, result, trigger, number) {
    const pre = document.createElement('pre');
    const focusedCode = code.cloneNode(true);
    const languageLabel = getLanguageLabel(code);

    pre.appendChild(focusedCode);
    focusView.codeContainer.replaceChildren(pre);
    createCodeTabs(focusView.codeContainer, pre, result, `focus-fragment-${number}`);
    focusView.codeContainer.classList.remove('is-dialogue');
    focusView.overlay.classList.add('is-code-view');
    focusView.title.textContent = `Kod do analizy · ${languageLabel} · fragment ${number}`;
    focusView.returnFocus = trigger;
    focusView.overlay.hidden = false;
    document.body.classList.add('code-focus-open');
    focusView.closeButton.focus();
}

function openDialogueView(focusView, quote, trigger, number) {
    const focusedDialogue = quote.cloneNode(true);
    focusedDialogue.querySelector('.dialogue-expand-btn')?.remove();

    focusView.codeContainer.replaceChildren(focusedDialogue);
    focusView.codeContainer.classList.add('is-dialogue');
    focusView.overlay.classList.remove('is-code-view');
    focusView.title.textContent = `Rozmowa Maciusia z Janem · dialog ${number}`;
    focusView.returnFocus = trigger;
    focusView.overlay.hidden = false;
    document.body.classList.add('code-focus-open');
    focusView.closeButton.focus();
}

function closeFocusView(focusView) {
    focusView.overlay.hidden = true;
    focusView.codeContainer.replaceChildren();
    focusView.codeContainer.classList.remove('is-dialogue');
    focusView.overlay.classList.remove('is-code-view');
    document.body.classList.remove('code-focus-open');
    focusView.returnFocus?.focus();
    focusView.returnFocus = null;
}

async function copyText(text) {
    if (navigator.clipboard && window.isSecureContext) {
        await navigator.clipboard.writeText(text);
        return;
    }

    const textArea = document.createElement('textarea');
    textArea.value = text;
    textArea.setAttribute('readonly', '');
    textArea.style.position = 'fixed';
    textArea.style.opacity = '0';
    document.body.appendChild(textArea);
    textArea.select();

    const copied = document.execCommand('copy');
    textArea.remove();

    if (!copied) {
        throw new Error('Nie udało się skopiować kodu.');
    }
}

function showStatus(button, label, className) {
    button.textContent = label;
    button.classList.add(className);

    window.setTimeout(() => {
        button.textContent = 'Kopiuj';
        button.classList.remove(className);
    }, 1800);
}
