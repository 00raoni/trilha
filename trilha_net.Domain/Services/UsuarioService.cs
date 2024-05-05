using AutoMapper;
using trilha_net.Domain.Arguments.Enums;
using trilha_net.Domain.Arguments.ViewModels;
using trilha_net.Domain.Exception;
using trilha_net.Domain.Interfaces.Repositories;
using trilha_net.Domain.Interfaces.Services;
using trilha_net.Domain.Models;
using trilha_net.Domain.Services.Base;

namespace trilha_net.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class UsuarioService : BaseService<IUsuarioRepository, Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapperTest;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioRepository"></param>
        /// <param name="mapper"></param>
        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            IMapper mapper
        )
            : base(usuarioRepository, mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapperTest = mapper;
        }
        public async Task AtualizarUsuario(RequestUsuario request)
        {
            await ValidarCadastro(request, TipoOperacao.Alteracao);
            var model = _mapperTest.Map<Usuario>(request);
            model.Status = TipoStatus.Ativo;
            await Atualizar(model);
        }
        public async Task<Guid> CriarUsuario(RequestUsuario request)
        {
            await ValidarCadastro(request, TipoOperacao.Inclusao);
            var model = _mapperTest.Map<Usuario>(request);
            model.Status = TipoStatus.Ativo;
            await Criar(model);
            return model.Id;
        }
        public async Task ValidarCadastro(RequestUsuario request, TipoOperacao tipo)
        {
            if (string.IsNullOrEmpty(request.Nome))
                throw new ProjetoException(TipoHttpCode.HTTP_400_BAD_REQUEST, "Nome é de preenchimento Obrigatório");
            if (string.IsNullOrEmpty(request.Email))
                throw new ProjetoException(TipoHttpCode.HTTP_400_BAD_REQUEST, "Email é de preenchimento Obrigatório");
            if (!ValidarCPF(request.CPF))
                throw new ProjetoException(TipoHttpCode.HTTP_400_BAD_REQUEST, "CPF inválido");

            if (tipo == TipoOperacao.Inclusao)
            {
                var result = await _usuarioRepository.ReturnList(x => x.Login == request.Login);
                if (result is not null && result.Any())
                    throw new ProjetoException(TipoHttpCode.HTTP_400_BAD_REQUEST, "Login já existente.");

                result = await _usuarioRepository.ReturnList(x => x.Email == request.Email);
                if (result is not null && result.Any())
                    throw new ProjetoException(TipoHttpCode.HTTP_400_BAD_REQUEST, "Email já existente.");
            }
            if (tipo == TipoOperacao.Alteracao)
            {
                var result = await _usuarioRepository.ReturnList(x => x.Login == request.Login && x.Id != request.Id);
                if (result is not null && result.Any())
                    throw new ProjetoException(TipoHttpCode.HTTP_400_BAD_REQUEST, "Alteração não permitida, Login já existente.");

                result = await _usuarioRepository.ReturnList(x => x.Email == request.Email && x.Id != request.Id);
                if (result is not null && result.Any())
                    throw new ProjetoException(TipoHttpCode.HTTP_400_BAD_REQUEST, "Alteração não permitida, Email já existente.");
            }
        }
        public bool ValidarCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
