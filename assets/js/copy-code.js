document.addEventListener('DOMContentLoaded', () => {
    const codeBlocks = document.querySelectorAll('.material-content pre > code');

    codeBlocks.forEach((code) => {
        const pre = code.parentElement;
        const wrapper = document.createElement('div');
        const button = document.createElement('button');

        wrapper.className = 'code-block';
        pre.parentNode.insertBefore(wrapper, pre);
        wrapper.appendChild(pre);

        button.type = 'button';
        button.className = 'copy-code-btn';
        button.textContent = 'Kopiuj';
        button.setAttribute('aria-label', 'Kopiuj kod do schowka');
        wrapper.appendChild(button);

        button.addEventListener('click', async () => {
            try {
                await copyText(code.textContent);
                showStatus(button, 'Skopiowano', 'is-copied');
            } catch (error) {
                showStatus(button, 'Błąd kopiowania', 'is-error');
            }
        });
    });
});

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
