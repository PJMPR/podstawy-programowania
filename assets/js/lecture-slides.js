document.addEventListener('DOMContentLoaded', () => {
    const content = document.querySelector('.material-content');
    const toggle = document.querySelector('.slide-mode-toggle');
    const controls = document.querySelector('.slide-controls');

    if (!content || !toggle || !controls) return;

    removeRedundantTextDiagrams(content);
    enhanceQuestions(content);
    const slides = buildSlides(content);
    const previous = controls.querySelector('.slide-prev');
    const next = controls.querySelector('.slide-next');
    const exit = controls.querySelector('.slide-exit');
    const counter = controls.querySelector('.slide-counter');
    const progress = controls.querySelector('.slide-progress span');
    let current = 0;
    let active = false;

    function showSlide(index, moveFocus = false) {
        current = Math.max(0, Math.min(index, slides.length - 1));
        slides.forEach((slide, slideIndex) => {
            const selected = slideIndex === current;
            slide.classList.toggle('is-current', selected);
            slide.setAttribute('aria-hidden', String(!selected));
        });
        previous.disabled = current === 0;
        next.disabled = current === slides.length - 1;
        counter.textContent = `${current + 1} / ${slides.length}`;
        progress.style.width = `${((current + 1) / slides.length) * 100}%`;
        slides[current].scrollTop = 0;
        history.replaceState(null, '', `#slajd-${current + 1}`);
        if (moveFocus) slides[current].focus({ preventScroll: true });
    }

    function setMode(enabled) {
        active = enabled;
        document.body.classList.toggle('is-slide-mode', enabled);
        toggle.setAttribute('aria-pressed', String(enabled));
        toggle.querySelector('.slide-mode-toggle-label').textContent = enabled ? 'Zamknij slajdy' : 'Tryb slajdów';
        controls.hidden = !enabled;

        if (enabled) {
            separateDiagramSlides(slides);
            splitOverflowingSlides(slides);
            const hashSlide = Number(location.hash.match(/^#slajd-(\d+)$/)?.[1]);
            showSlide(Number.isFinite(hashSlide) ? hashSlide - 1 : current, true);
        } else {
            slides.forEach((slide) => {
                slide.classList.remove('is-current');
                slide.removeAttribute('aria-hidden');
            });
            history.replaceState(null, '', `${location.pathname}${location.search}`);
            toggle.focus({ preventScroll: true });
        }
    }

    toggle.addEventListener('click', () => setMode(!active));
    exit.addEventListener('click', () => setMode(false));
    previous.addEventListener('click', () => showSlide(current - 1, true));
    next.addEventListener('click', () => showSlide(current + 1, true));

    document.addEventListener('mermaid:rendered', () => {
        separateDiagramSlides(slides);
        if (active) {
            splitOverflowingSlides(slides);
            showSlide(current);
        }
    });

    let resizeTimer;
    window.addEventListener('resize', () => {
        if (!active) return;
        window.clearTimeout(resizeTimer);
        resizeTimer = window.setTimeout(() => {
            splitOverflowingSlides(slides);
            showSlide(current);
        }, 120);
    });

    document.addEventListener('keydown', (event) => {
        if (!active || document.querySelector('.code-focus-overlay:not([hidden]), .mermaid-focus-overlay:not([hidden])')) return;
        const interactive = event.target.closest('button, a, input, textarea, select, code, pre');
        if (interactive && !event.target.closest('.slide-controls')) return;

        if (['ArrowRight', 'PageDown', ' '].includes(event.key)) {
            event.preventDefault();
            showSlide(current + 1, true);
        } else if (['ArrowLeft', 'PageUp'].includes(event.key)) {
            event.preventDefault();
            showSlide(current - 1, true);
        } else if (event.key === 'Home') {
            event.preventDefault();
            showSlide(0, true);
        } else if (event.key === 'End') {
            event.preventDefault();
            showSlide(slides.length - 1, true);
        } else if (event.key === 'Escape') {
            setMode(false);
        }
    });

    if (/^#slajd-\d+$/.test(location.hash)) setMode(true);
});

function buildSlides(content) {
    const nodes = Array.from(content.children);
    const fragment = document.createDocumentFragment();
    const slides = [];
    let slide = null;

    nodes.forEach((node) => {
        if (!slide || node.tagName === 'H2' || node.tagName === 'H3') {
            slide = document.createElement('section');
            slide.className = 'lecture-slide';
            slide.tabIndex = -1;
            slide.setAttribute('role', 'group');
            slides.push(slide);
            fragment.appendChild(slide);
        }
        slide.appendChild(node);
    });

    slides.forEach((item, index) => {
        const heading = item.querySelector('h2');
        item.setAttribute('aria-label', heading?.textContent || `Slajd ${index + 1}`);
    });
    content.appendChild(fragment);
    return slides;
}

function splitOverflowingSlides(slides) {
    for (let index = 0; index < slides.length; index += 1) {
        const slide = slides[index];

        while (slide.scrollHeight > slide.clientHeight + 2 && slide.children.length > 2) {
            let continuation = slides[index + 1];

            if (!continuation?.classList.contains('is-auto-continuation')) {
                continuation = createContinuationSlide(slide);
                slide.after(continuation);
                slides.splice(index + 1, 0, continuation);
            }

            const node = slide.lastElementChild;
            continuation.insertBefore(node, continuation.children[1] || null);
        }

        if (slide.scrollHeight > slide.clientHeight + 2) {
            slide.classList.add('is-dense-slide');
        }
    }

    slides.forEach((slide, index) => {
        const heading = slide.querySelector('h2, h3');
        slide.setAttribute('aria-label', heading?.textContent || `Slajd ${index + 1}`);
    });
}

function createContinuationSlide(source) {
    const slide = document.createElement('section');
    const sourceHeading = source.querySelector('h2, h3');
    const heading = sourceHeading?.cloneNode(true) || document.createElement('h2');

    slide.className = 'lecture-slide is-auto-continuation';
    slide.tabIndex = -1;
    slide.setAttribute('role', 'group');
    heading.classList.add('slide-continuation-title');
    heading.textContent = `${sourceHeading?.textContent || 'Materiał'} — ciąg dalszy`;
    slide.appendChild(heading);
    return slide;
}

function removeRedundantTextDiagrams(content) {
    content.querySelectorAll('p').forEach((paragraph) => {
        if (!paragraph.textContent.trim().startsWith('Wersja tekstowa diagramu:')) return;
        const textDiagram = paragraph.nextElementSibling;
        if (textDiagram?.matches('.highlighter-rouge, pre')) textDiagram.remove();
        paragraph.remove();
    });
}

function enhanceQuestions(content) {
    const answers = Array.from(content.querySelectorAll('p')).filter((paragraph) => {
        const label = paragraph.querySelector(':scope > strong:first-child')?.textContent.trim().toLowerCase();
        return label?.startsWith('odpowiedź') || label?.startsWith('oczekiwana odpowiedź');
    });

    answers.forEach((answer, index) => {
        const button = document.createElement('button');
        const answerBox = document.createElement('div');
        const answerId = `lecture-answer-${index + 1}`;

        answerBox.className = 'lecture-answer';
        answerBox.id = answerId;
        answerBox.hidden = true;
        answer.parentNode.insertBefore(answerBox, answer);
        answerBox.appendChild(answer);

        button.type = 'button';
        button.className = 'answer-toggle';
        button.setAttribute('aria-expanded', 'false');
        button.setAttribute('aria-controls', answerId);
        button.innerHTML = '<span aria-hidden="true">?</span><span>Pokaż odpowiedź</span>';
        answerBox.before(button);

        findPreviousQuestionHeading(button)?.classList.add('question-heading');
        button.addEventListener('click', () => {
            const willOpen = answerBox.hidden;
            answerBox.hidden = !willOpen;
            button.setAttribute('aria-expanded', String(willOpen));
            button.lastElementChild.textContent = willOpen ? 'Ukryj odpowiedź' : 'Pokaż odpowiedź';
        });
    });
}

function findPreviousQuestionHeading(element) {
    let current = element.previousElementSibling;
    while (current) {
        if (/^H[23]$/.test(current.tagName)) return current;
        current = current.previousElementSibling;
    }
    return null;
}

function separateDiagramSlides(slides) {
    for (let index = 0; index < slides.length; index += 1) {
        const slide = slides[index];
        const figures = Array.from(slide.querySelectorAll(':scope > .mermaid-figure'));

        figures.forEach((figure) => {
            const contentBesidesDiagram = Array.from(slide.children).filter((child) =>
                child !== figure && child.tagName !== 'HR' && !child.classList.contains('slide-continuation-title')
            );
            if (contentBesidesDiagram.length <= 1) return;

            const diagramSlide = createContinuationSlide(slide);
            diagramSlide.classList.add('is-diagram-slide');
            diagramSlide.querySelector('.slide-continuation-title').textContent = 'Diagram';
            diagramSlide.appendChild(figure);
            slide.after(diagramSlide);
            slides.splice(index + 1, 0, diagramSlide);
            index += 1;
        });
    }
}
