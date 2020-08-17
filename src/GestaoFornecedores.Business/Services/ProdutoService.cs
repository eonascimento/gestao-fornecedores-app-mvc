﻿using GestaoFornecedores.Business.Interfaces.Respositories;
using GestaoFornecedores.Business.Interfaces.Services;
using GestaoFornecedores.Business.Models;
using GestaoFornecedores.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace GestaoFornecedores.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;
            await _produtoRepository.Adicionar(produto);

        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;
            await _produtoRepository.Atualizar(produto);
        }


        public async Task Remover(Guid id)
        {
            await _produtoRepository.Remover(id);
        }
        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}
