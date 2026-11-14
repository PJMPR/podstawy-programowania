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
        diagrams.forEach(({ figure }) => figure.classList.add('is-rendered'));
    } catch (error) {
        diagrams.forEach(({ figure, diagram, source }) => {
            showMermaidFallback(figure, diagram, source);
        });

        console.error('Nie udało się wyrenderować diagramów Mermaid.', error);
    }
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
