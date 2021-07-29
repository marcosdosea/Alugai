function resetForm() {
    document.getElementById('rua').value=("");
    document.getElementById('bairro').value=("");
    document.getElementById('cidade').value=("");
    document.getElementById('uf').value=("");
    document.getElementById('estado').value=("");
}

function getDados(conteudo) {
    if (!("erro" in conteudo)) {
        document.getElementById('rua').value=(conteudo.logradouro);
        document.getElementById('bairro').value=(conteudo.bairro);
        document.getElementById('cidade').value=(conteudo.localidade);
        document.getElementById('uf').value=(conteudo.uf);
        document.getElementById('estado').value=(conteudo.uf);
    } 
    else {
        resetForm();
        alert("CEP não encontrado.");
    }
}

function pesquisacep(valor) {

    var cep = valor.replace(/\D/g, '');

    if (cep != "") {

        var validacep = /^[0-9]{8}$/;

        if(validacep.test(cep)) {

            var script = document.createElement('script');
            script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=getDados';
            document.body.appendChild(script);

        }
        else {
            resetForm();
            alert("Formato de CEP inválido.");
        }
    } 
    else {
        resetForm();
    }
};
