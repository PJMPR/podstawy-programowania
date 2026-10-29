document.addEventListener('DOMContentLoaded', () => {
    const codeBlocks = document.querySelectorAll('.material-content pre > code');
    const focusView = createFocusView();

    codeBlocks.forEach((code, index) => {
        const pre = code.parentElement;
        const wrapper = document.createElement('div');
        const actions = document.createElement('div');
        const copyButton = document.createElement('button');
        const focusButton = document.createElement('button');

        wrapper.className = 'code-block';
        pre.parentNode.insertBefore(wrapper, pre);
        wrapper.appendChild(pre);

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
            openFocusView(focusView, code, focusButton, index + 1);
        });
    });
});

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

function openFocusView(focusView, code, trigger, number) {
    const pre = document.createElement('pre');
    const focusedCode = code.cloneNode(true);

    pre.appendChild(focusedCode);
    focusView.codeContainer.replaceChildren(pre);
    focusView.title.textContent = `Kod do analizy · fragment ${number}`;
    focusView.returnFocus = trigger;
    focusView.overlay.hidden = false;
    document.body.classList.add('code-focus-open');
    focusView.closeButton.focus();
}

function closeFocusView(focusView) {
    focusView.overlay.hidden = true;
    focusView.codeContainer.replaceChildren();
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
