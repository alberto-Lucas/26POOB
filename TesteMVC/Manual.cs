namespace TesteMVC
{
    //Classe para uso exclusivo para comentarios
    //e explicação do passo a passo para criar
    //um projeto MVC
    internal class Manual
    {
        //*********Primeiro Passo****************
        //Iniciar com a criação das camdas (PASTAS)
        //Projeto -> Adicionar -> Nova Pasta
        //Com nomes de acordo com suas camdas
        //Models - Camada de Modelo (Classes de Objetos)
        //Views - Camada de Apresentação (Telas)
        //Controllers - Camada de Negocio (Classe de manutenção)
        //OBS: Respeitar o nome das pastas para de acordo
        //com sua respectiva camada
        //OBS2: Fica opcional a utilizar o nome no Plural
        //Ou seja tanto Model quanto Models estão corretas
        //*********Segundo Passo****************
        //Popular as nossas camadas com seus respectivos arquivos
        //Neste momento iremos para a cada de modelo
        //pois está na base da piramide
        //Para criar as classes de objeto 
        //Basta adicionar a classe diretamente dentro da pasta
        //desejada
        //Camda de Modelo, não possui uma regra de nomenclatura
        //Ou seja, se eu preciso criar a classe Pessoa, posso
        //chama-la apenas de Pessoa
        //OBS: Em alguma documentação a camada Model sugere adicionar
        //a nomenclara DTO ao final do nome da classe
        //No exemplo acima ficaria PessoaDTO 
        //OBS: DTO (Data Transfer Object) ou seja
        //objeto de transferencia de dados
        //onde é armazenada a informação q seja manipulada
        //Ainda classe MODEL criamos uma classe de coleção
        //para cada classe de objeto
        //ou seja o objeto armazena apenas uma informação por instancia
        //e a coleção armazena um serie de objeto
        //no exemplo tempo a classe
        //Pessoa então teremos a PessoaCollection
        //Principalmente utilizada para preencher os dados
        //retornados do banco de dados
        //Lembrem-se sempre que criar uma classe de objeto
        //adicionar a classe de coleção daquele objeto no final do arquivo
        //sempre usando a nomenclatura collection no final
        //Ex: PessoaCollection
        //*********Terceiro Passo****************
        //Iremos para a camda de Negocios
        //ou seja a camada de manipulação dos objetos
        //e regras de funcionamento do sistema
        //Todo objeto da camada Model tera uma classe de manutenção
        //nesta camada usamos a nomenclatura Controller
        //Ou seja para a classe Pessoa teremos a 
        //PessoaController
        //Esta ira intermediar a manipulação da informação
        //entre a tela e a fonte de dados(Arquivo.txt,
        //Banco de dados, API, etc...)
        //*********Qaurto Passo****************
        //Podemos finalizar na camada de Apresentação
        //como desenvolvimento do front-end do projeto
        //ou seja onde iremos criar todas as tela do sistema
        //OBS: IMPORTANTE como as tela serão criada em uma camada
        //é preciso atualizar a chamada da tela inicial do sistema
        //dentro do arquivo program.cs
        //OBS2: em alguns projetos, como ja é usado a abreviação
        //frm para destacar o arquivo é um formulario
        //não é preciso adicionar a nomenclatura View
        //no final do nome
        //porém se não é utilizado o frm é preciso
        //adicionara a nomenclatura
        //Ex: frmPessoaCadastro ou PessoaCadastroView
        //Para criação da tela
        //basta adicionar um form na pasta Views

    }
}
