using System;
using System.Collections.Generic;
using System.Text;

namespace Practica_Empresa
{
    interface IEmpresasRepositorio
    {
        OperationResult Create(Info empresa);
        OperationResult GetAll();

        OperationResult FindByRNC(string rnc);
        OperationResult Update(Info Aempresa, string rnc);
        OperationResult SoftDelete(string rnc);

    }
}
