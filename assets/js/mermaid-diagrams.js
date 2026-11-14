const MERMAID_MODULE_URL = 'https://cdn.jsdelivr.net/npm/mermaid@12.3.0/dist/mermaid.esm.min.mjs';

const mermaidCodeBlocks = findMermaidCodeBlocks();

if (mermaidCodeBlocks.length > 0) {
    renderMermaidDiagrams(mermaidCodeBlocks);
}

function findMermaidCodeBlocks() {
    const candidates = document.querySelectorAll(
        '.material-content code.language-mermaid, ' +
        '.material-content .language-mermaid code, ' +
        '.page-article code.language-mermaid, ' +
        '.page-article .language-mermaid code'
    );

    return Array.from(new Set(candidates));
}

async function renderMermaidDiagrams(codeBlocks) {
    const diagrams = codeBlocks.map((code, index) => replaceCodeBlock(code, index));
    const focusView = createMermaidFocusView();

    try {
        const { default: mermaid } = await import(MERMAID_MODULE_URL);

        mermaid.initialize({
            startOnLoad: false,
            securityLevel: 'strict',
            theme: 'dark',
            fontFamily: 'Inter, Segoe UI, sans-serif',
            themeVariables: {
                background: '#0d1725',
                primaryColor: '#111f31',
                primaryTextColor: '#e7f0f5',
                primaryBorderColor: '#55e6dc',
                secondaryColor: '#191d35',
                secondaryTextColor: '#e7f0f5',
                secondaryBorderColor: '#b7a7ff',
                tertiaryColor: '#231b17',
                tertiaryTextColor: '#e7f0f5',
                tertiaryBorderColor: '#ffbd66',
                lineColor: '#91a5b4',
                textColor: '#e7f0f5',
                mainBkg: '#111f31',
                nodeBorder: '#55e6dc',
                clusterBkg: '#0d1725',
                clusterBorder: '#29445c',
                edgeLabelBackground: '#0d1725',
                noteBkgColor: '#231b17',
                noteBorderColor: '#ffbd66',
                noteTextColor: '#e7f0f5'
            },
            flowchart: {
                htmlLabels: true,
                useMaxWidth: true,
                curve: 'basis'
            },
            sequence: {
                useMaxWidth: true
            }
        });

        await mermaid.run({ nodes: diagrams.map(({ diagram }) => diagram) });
        diagrams.forEach(({ figure }, index) => {
            figure.classList.add('is-rendered');
            addExpandButton(figure, focusView, index + 1);
        });
    } catch (error) {
        diagrams.forEach(({ figure, diagram, source }) => {
            showMermaidFallback(figure, diagram, source);
        });

        console.error('Nie udało się wyrenderować diagramów Mermaid.', error);
    }
}

function addExpandButton(figure, focusView, number) {
    if (!figure.querySelector('svg')) {
        return;
    }

    const button = document.createElement('button');

    button.type = 'button';
    button.className = 'mermaid-expand-btn';
    button.textContent = 'Powiększ';
    button.setAttribute('aria-label', `Powiększ diagram ${number}`);
    figure.appendChild(button);

    button.addEventListener('click', () => {
        openMermaidFocusView(focusView, figure, button, number);
    });
}

function createMermaidFocusView() {
    const overlay = document.createElement('div');
    const dialog = document.createElement('section');
    const header = document.createElement('header');
    const title = document.createElement('h2');
    const closeButton = document.createElement('button');
    const content = document.createElement('div');

    overlay.className = 'mermaid-focus-overlay';
    overlay.hidden = true;
    dialog.className = 'mermaid-focus-dialog';
    dialog.setAttribute('role', 'dialog');
    dialog.setAttribute('aria-modal', 'true');
    dialog.setAttribute('aria-labelledby', 'mermaid-focus-title');
    header.className = 'mermaid-focus-header';
    title.id = 'mermaid-focus-title';
    title.textContent = 'Diagram';
    closeButton.type = 'button';
    closeButton.className = 'mermaid-focus-close';
    closeButton.textContent = 'Zamknij';
    closeButton.setAttribute('aria-label', 'Zamknij powiększony diagram');
    content.className = 'mermaid-focus-content';

    header.append(title, closeButton);
    dialog.append(header, content);
    overlay.appendChild(dialog);
    document.body.appendChild(overlay);

    const focusView = {
        overlay,
        title,
        closeButton,
        content,
        returnFocus: null
    };

    closeButton.addEventListener('click', () => closeMermaidFocusView(focusView));
    overlay.addEventListener('click', (event) => {
        if (event.target === overlay) {
            closeMermaidFocusView(focusView);
        }
    });
    document.addEventListener('keydown', (event) => {
        if (event.key === 'Escape' && !overlay.hidden) {
            closeMermaidFocusView(focusView);
        }
    });

    return focusView;
}

function openMermaidFocusView(focusView, figure, trigger, number) {
    const sourceSvg = figure.querySelector('svg');

    if (!sourceSvg) {
        return;
    }

    const modalSvg = cloneSvgWithUniqueIds(sourceSvg, `modal-diagram-${number}`);
    const container = document.createElement('div');

    container.className = 'mermaid-focus-diagram';
    container.appendChild(modalSvg);
    focusView.returnFocus = trigger;
    focusView.title.textContent = `Diagram ${number}`;
    focusView.content.replaceChildren(container);
    focusView.overlay.hidden = false;
    document.body.classList.add('mermaid-focus-open');
    focusView.closeButton.focus();
}

function closeMermaidFocusView(focusView) {
    focusView.overlay.hidden = true;
    focusView.content.replaceChildren();
    document.body.classList.remove('mermaid-focus-open');
    focusView.returnFocus?.focus();
    focusView.returnFocus = null;
}

function cloneSvgWithUniqueIds(sourceSvg, prefix) {
    const clone = sourceSvg.cloneNode(true);
    const idMap = new Map();
    const elementsWithIds = [clone, ...clone.querySelectorAll('[id]')]
        .filter((element) => element.id);

    elementsWithIds.forEach((element, index) => {
        const oldId = element.id;
        const newId = `${prefix}-${index}-${oldId}`;

        idMap.set(oldId, newId);
        element.id = newId;
    });

    clone.querySelectorAll('*').forEach((element) => {
        Array.from(element.attributes).forEach((attribute) => {
            let value = attribute.value;

            idMap.forEach((newId, oldId) => {
                value = value
                    .replaceAll(`url(#${oldId})`, `url(#${newId})`)
                    .replaceAll(`#${oldId}`, `#${newId}`);
            });

            if (value !== attribute.value) {
                element.setAttribute(attribute.name, value);
            }
        });
    });

    clone.removeAttribute('width');
    clone.removeAttribute('height');
    clone.style.removeProperty('max-width');
    clone.setAttribute('aria-hidden', 'true');

    return clone;
}

function replaceCodeBlock(code, index) {
    const source = code.textContent.trim();
    const pre = code.closest('pre');
    const highlightedBlock = pre?.closest('.highlighter-rouge');
    const sourceBlock = highlightedBlock ?? pre;
    const figure = document.createElement('figure');
    const diagram = document.createElement('div');
    const caption = document.createElement('figcaption');

    figure.className = 'mermaid-figure';
    figure.setAttribute('aria-label', `Diagram ${index + 1}`);
    diagram.className = 'mermaid';
    diagram.textContent = source;
    caption.className = 'mermaid-caption';
    caption.textContent = `Diagram ${index + 1}`;
    figure.append(diagram, caption);
    sourceBlock.replaceWith(figure);

    return { figure, diagram, source };
}

function showMermaidFallback(figure, diagram, source) {
    const message = document.createElement('p');
    const pre = document.createElement('pre');
    const code = document.createElement('code');

    figure.classList.add('has-error');
    message.className = 'mermaid-error';
    message.textContent = 'Diagramu nie udało się wyrenderować. Poniżej znajduje się jego opis źródłowy.';
    code.textContent = source;
    pre.appendChild(code);
    diagram.replaceWith(message, pre);
}
