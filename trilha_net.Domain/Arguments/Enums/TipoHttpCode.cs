using System.ComponentModel;

namespace trilha_net.Domain.Arguments.Enums
{
    public enum TipoHttpCode
    {
        /// <summary>
        /// 200 Requisição Ok
        /// </summary>
        [Description("Requisição inválida")]
        HTTP_200_OK = 200,
        /// <summary>
        /// 400 Requisição inválida
        /// Essa response significa que o servidor não entendeu a requisição pois está com uma sintaxe inválida.
        /// </summary>
        [Description("Requisição inválida")]
        HTTP_400_BAD_REQUEST = 400,

        /// <summary>
        /// 401 Não autorizado
        /// Embora o padrão HTTP especifique "unauthorized", semanticamente, essa response significa "unauthenticated".
        /// Ou seja, o cliente deve se autenticar para obter a response solicitada.
        /// </summary>
        [Description("Não autorizado")]
        HTTP_401_UNAUTHORIZED = 401,

        /// <summary>
        /// Este código de response está reservado para uso futuro.
        /// O objetivo inicial da criação deste código era usá-lo para systems digitais de pagamento porém ele não está sendo usado atualmente.
        /// </summary>
        [Description("Payment Required")]
        HTTP_402_PAYMENT_REQUIRED = 402,

        /// <summary>
        /// 403 Acesso negado
        /// O cliente não tem direitos de acesso ao conteúdo portanto o servidor está rejeitando dar a response.
        /// Diferente do código 401, aqui a identidade do cliente é conhecida.
        /// </summary>
        [Description("Acesso negado")]
        HTTP_403_FORBIDDEN = 403,

        /// <summary>
        /// 404 Não encontrado
        /// O servidor não pode encontrar o recurso solicitado. 
        /// Este código de response talvez seja o mais famoso devido à frequência com que acontece na web.
        /// </summary>
        [Description("Não encontrado.")]
        HTTP_404_NOT_FOUND = 404,

        /// <summary>
        /// 405 Método solicitado ao servidor está desativado.
        /// O método de solicitação é conhecido pelo servidor, mas foi desativado e não pode ser usado. 
        /// Os dois métodos obrigatórios, GET e HEAD, nunca devem ser desabilitados e não devem retornar este código de erro.
        /// </summary>
        [Description("Método solicitado ao servidor está desativado.")]
        HTTP_405_METHOD_NOT_ALLOWED = 405,

        /// <summary>
        /// 406 Não aceitável
        /// Essa response é enviada quando o servidor da Web após realizar a negociação de conteúdo orientada pelo servidor, 
        /// não encontra nenhum conteúdo seguindo os critérios fornecidos pelo agente do usuário.
        /// </summary>
        [Description("Não aceitável.")]
        HTTP_406_NOT_ACCEPTABLE = 406,

        /// <summary>
        /// Semelhante ao 401 porem é necessário que a autenticação seja feita por um proxy.
        /// </summary>
        [Description("Proxy Authentication Required")]
        HTTP_407_PROXY_AUTHENTICATION_REQUIRED = 407,

        /// <summary>
        /// Esta response é enviada por alguns servidores em uma conexão ociosa, 
        /// mesmo sem qualquer requisição prévia pelo cliente.
        /// Ela significa que o servidor gostaria de derrubar esta conexão em desuso. 
        /// Esta response é muito usada já que alguns navegadores, como Chrome, Firefox 27+, ou IE9, 
        /// usam mecanismos HTTP de pré-conexão para acelerar a navegação.
        /// Note também que alguns servidores meramente derrubam a conexão sem enviar esta message.
        /// </summary>
        [Description("Request Timeout")]
        HTTP_408_REQUEST_TIMEOUT = 408,

        /// <summary>
        /// Esta response será enviada quando uma requisição conflitar com o estado atual do servidor.
        /// </summary>
        [Description("Conflict")]
        HTTP_409_CONFLICT = 409,

        /// <summary>
        /// Esta response será enviada quando o conteúdo requisitado foi permanentemente deletado do servidor, 
        /// sem nenhum endereço de redirecionamento.É experado que clientes removam seus caches e links para o recurso. 
        /// A especificação HTTP espera que este código de status seja usado para "serviços promocionais de tempo limitado". 
        /// APIs não devem se sentir obrigadas a indicar que recursos foram removidos com este código de status.
        /// </summary>
        [Description("Gone")]
        HTTP_410_GONE = 410,

        /// <summary>
        /// O servidor rejeitou a requisição porque o campo Content-Length do cabeçalho não está definido e o servidor o requer.
        /// </summary>
        [Description("Length Required")]
        HTTP_411_LENGTH_REQUIRED = 411,

        /// <summary>
        /// O cliente indicou nos seus cabeçalhos pré-condições que o servidor não atende.
        /// </summary>
        [Description("Precondition Failed")]
        HTTP_412_PRECONDITION_FAILED = 412,

        /// <summary>
        /// A entidade requisição é maior do que os limites definidos pelo servidor, 
        /// o servidor pode fechar a conexão ou retornar um campo de cabeçalho Retry-After.
        /// </summary>
        [Description("Payload Too Large")]
        HTTP_413_PAYLOAD_TOO_LARGE = 413,

        /// <summary>
        /// A URI requisitada pelo cliente é maior do que o servidor aceita para interpretar.
        /// </summary>
        [Description("URI Too Long")]
        HTTP_414_URI_Too_Long = 414,

        /// <summary>
        /// O formato de mídia dos data requisitados não é suportado pelo servidor, então o servidor rejeita a requisição.
        /// </summary>
        [Description("Unsupported Media Type")]
        HTTP_415_UNSUPPORTED_MEDIA_TYPE = 415,

        /// <summary>
        /// O trecho especificado pelo campo Range do cabeçalho na requisição não pode ser preenchido, 
        /// é possível que o trecho esteja fora do tamanho dos data da URI alvo.
        /// </summary>
        [Description("Requested Range Not Satisfiable")]
        HTTP_416_REQUESTED_RANGE_NOT_SATISFIABLE = 416,

        /// <summary>
        /// Este código de response significa que a expectativa indicada pelo campo Expect do cabeçalho da requisição não pode ser 
        /// satisfeita pelo servidor.
        /// </summary>
        [Description("Expectation Failed")]
        HTTP_417_EXPECTATION_FAILED = 417,

        /// <summary>
        /// 418 Eu sou uma chaleira.
        /// O servidor recusa a tentativa de coar café num bule de chá.
        /// </summary>
        [Description("Eu sou uma chaleira.")]
        HTTP_418_IM_A_TEAPOT = 418,

        /// <summary>
        /// A requisição foi direcionada a um servidor inapto a produzir a response. 
        /// Pode ser enviado por um servidor que não está configurado para produzir responses para a combinação de esquema ("scheme") 
        /// e autoridade inclusas na URI da requisição.
        /// </summary>
        [Description("Misdirected Request")]
        HTTP_421_MISDIRECTED_REQUEST = 421,

        /// <summary>
        /// A requisição está bem formada mas inabilitada para ser seguida devido a errors semânticos.
        /// (WebDAV (en-US))
        /// </summary>
        [Description("Unprocessable Entity")]
        HTTP_422_UNPROCESSABLE_ENTITY = 422,

        /// <summary>
        /// O recurso sendo acessado está travado.
        /// (WebDAV (en-US))
        /// </summary>
        [Description("Locked ")]
        HTTP_423_LOCKED = 423,

        /// <summary>
        /// A requisição falhou devido a falha em requisição prévia.
        /// (WebDAV (en-US)): 424
        /// </summary>
        [Description("Failed Dependency ")]
        HTTP_424_FAILED_DEPENDENCY = 424,
        
        /// <summary>
        /// Indica que o servidor não está disposto a arriscar processar uma requisição que pode ser refeita.
        /// </summary>
        [Description("Too Early")]
        HTTP_425_TOO_EARLY = 425,

        /// <summary>
        /// O servidor se recusa a executar a requisição usando o protocolo corrente mas estará pronto a fazê-lo
        /// após o cliente atualizar para um protocolo diferente.
        /// O servidor envia um cabeçalho Upgrade (en-US) numa response 426 para indicar o(s) protocolo(s) requeridos.
        /// </summary>
        [Description("Upgrade Required")]
        HTTP_426_UPGRADE_REQUIRED = 426,

        /// <summary>
        /// O servidor de origem requer que a response seja condicional.
        /// Feito para prevenir o problema da 'atualização perdida', onde um cliente pega o estado de um recurso (GET) , 
        /// modifica-o, e o põe de volta no servidor (PUT), enquanto um terceiro modificou o estado no servidor, levando a um conflito.
        /// </summary>
        [Description("Precondition Required")]
        HTTP_428_PRECONDITION_REQUIRED = 428,

        /// <summary>
        /// O usuário enviou muitas requisições num dado tempo ("limitação de frequência").
        /// </summary>
        [Description("Too Many Requests")]
        HTTP_429_TOO_MANY_REQUESTS = 429,
       
        /// <summary>
        /// O servidor não quer processar a requisição porque os campos de cabeçalho são muito grandes.
        /// A requisição PODE ser submetida novemente depois de reduzir o tamanho dos campos de cabeçalho.
        /// </summary>
        [Description("Request Header Fields Too Large")]
        HTTP_431_REQUEST_HEADER_FIELDS_TOO_LARGE = 431,

        /// <summary>
        /// O usuário requisitou um recurso ilegal, tal como uma página censurada por um governo.
        /// </summary>
        [Description("Unavailable For Legal Reasons")]
        HTTP_451_UNAVAILABLE_FOR_LEGAL_REASONS = 451,

        //Respostas de erro do Servidor

        /// <summary>
        /// 500 - Erro no servidor.
        /// O servidor encontrou uma situação com a qual não sabe lidar.
        /// </summary>
        [Description("Erro no servidor.")]
        HTTP_500_INTERNAL_SERVER_ERROR = 500,

        /// <summary>
        /// O método da requisição não é suportado pelo servidor e não pode ser manipulado. 
        /// Os únicos métodos exigidos que servidores suportem (e portanto não devem retornar este código) são GET e HEAD.
        /// </summary>
        [Description("Not Implemented")]
        HTTP_501_NOT_IMPLEMENTED = 501,

        /// <summary>
        /// 502 - Falha na integração.
        /// Esta response de erro significa que o servidor,
        /// ao trabalhar como um gateway a fim de obter uma response necessária para manipular a requisição, obteve uma response inválida.
        /// </summary>
        [Description("Falha na integração.")]
        HTTP_502_BAD_GATEWAY = 502,

        /// <summary>
        /// O servidor não está pronto para manipular a requisição.
        /// Causas comuns são um servidor em manutenção ou sobrecarregado.
        /// Note que junto a esta response, uma página amigável explicando o problema deveria ser enviada.
        /// Estas responses devem ser usadas para condições temporárias e o cabeçalho HTTP Retry-After: 
        /// deverá, se possível, conter o tempo estimado para recuperação do serviço.
        /// O webmaster deve também tomar cuidado com os cabeçalhos relacionados com o cache que são enviados com esta response, 
        /// já que estas responses de condições temporárias normalmente não deveriam ser postas em cache.
        /// </summary>
        [Description("Service Unavailable")]
        HTTP_503_SERVICE_UNAVAILABLE = 503,

        /// <summary>
        /// 504 - Tempo esgotado na conexão com integração.
        /// Esta response de erro é dada quando o servidor está atuando como um gateway e não obtém uma response a tempo.
        /// </summary>
        [Description("Tempo esgotado na conexão com integração.")]
        HTTP_504_GATEWAY_TIMEOUT = 504,

        /// <summary>
        /// A versão HTTP usada na requisição não é suportada pelo servidor.
        /// </summary>
        [Description("HTTP Version Not Supported")]
        HTTP_505_HTTP_VERSION_NOT_SUPPORTED = 505,

        /// <summary>
        /// O servidor tem um erro de configuração interno: 
        /// a negociação transparente de conteúdo para a requisição resulta em uma referência circular.
        /// </summary>
        [Description("Variant Also Negotiates")]
        HTTP_506_VARIANT_ALSO_NEGOTIATES = 506,

        /// <summary>
        /// O servidor tem um erro interno de configuração: 
        /// o recurso variante escolhido está configurado para entrar em negociação transparente de conteúdo com ele mesmo, 
        /// e portanto não é uma ponta válida no processo de negociação.
        /// (WebDAV (en-US))
        /// </summary>
        [Description("Insufficient Storage")]
        HTTP_507_INSUFFICIENT_STORAGE = 507,

        /// <summary>
        /// O servidor detectou um looping infinito ao processar a requisição.
        /// </summary>
        [Description("Loop Detected ")]
        HTTP_508_LOOP_DETECTED = 508,

        /// <summary>
        /// Exigem-se extenções posteriores à requisição para o servidor atendê-la.
        /// </summary>
        [Description("Not Extended")]
        HTTP_510_NOT_EXTENDED = 510,

        /// <summary>
        /// O código de status 511 indica que o cliente precisa se autenticar para ganhar acesso à rede.
        /// </summary>
        [Description("Network Authentication Required")]
        HTTP_511_NETWORK_AUTHENTICATION_REQUIRED = 511,
    }
}
