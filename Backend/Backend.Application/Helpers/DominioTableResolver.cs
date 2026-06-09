public static class DominioTableResolver
{
    private static readonly Dictionary<string, string>
        Tables =
        new()
        {
            ["Sigla Departamento Meio Ambiente"] =
                "GEA_TX_SIGLA_DEPTO_MEIO_AMBIENTE",

            ["Nome Área Gestora CPTM"] =
                "GEA_TX_NM_AREA_GESTORA_CPTM",

            ["Diretoria Gerência Departamento CPTM"] =
                "GEA_DIR_GER_DEPTO_CPTM",

            ["Natureza do PGA"] =
                "GEA_TX_NATUREZA_DO_PGA",

            ["Status Desvio Ambiental"] =
                "GEA_TX_STATUS_DO_DESVIO_AMBIENTAL",

            ["Status Registro BD"] =
                "GEA_TX_STATUS_DO_REGISTRO_NO_BD",

            ["Municipio"] =
                "GEA_TX_MUNICIPIO",

            ["Linha CPTM"] =
                "GEA_TX_LINHA_CPTM",

            ["Via CPTM"] =
                "GEA_TX_VIA_CPTM",

            ["Trecho e Sentido CPTM"] =
                "GEA_TX_TRECHO_E_SENTIDO_CPTM",

            ["Estacao CPTM"] =
                "GEA_TX_ESTACAO_CPTM",

            ["Tipo Proprietario"] =
                "TIPO_PROPRIETARIO",

            ["Tipo Proprietario L13"] =
                "TIPO_PROPRIETARIO_L13",

            ["Proprietario"] =
                "GEA_TX_PROPRIETARIO",

            ["Sim Nao"] =
                "GEA_SIM_NAO",

            ["Tipo Atividade Listada"] =
                "EF_TX_TIPO_ATIVIDADE_LISTADA",

            ["Tipo DRA Listado"] =
                "EF_TX_TIPO_DRA_LISTADO",

            ["Tipo Atividade CPTM"] =
                "EF_TX_TIPO_ATIVIDADE_CPTM",

            ["Nome Local Atividade"] =
                "EF_TX_NM_LOCAL_ATIV",

            ["Origem Efluente"] =
                "EF_TX_ORIGEM_EFLUENTE",

            ["Fonte Geradora"] =
                "EF_TX_FONTE_GERADORA",

            ["Tipo Destinacao"] =
                "EF_TX_TIPO_DESTINACAO",

            ["Tipo Veiculo"] =
                "EF_TX_TIPO_VEICULO",
        };

    public static string GetTableName(string dominio)
    {
        if (Tables.TryGetValue(dominio, out var tableName))
        {
            return tableName;
        }

        throw new KeyNotFoundException(
            $"Domínio '{dominio}' não encontrado.");
    }

    public static IReadOnlyDictionary<
        string,
        string> GetAll()
        {
            return Tables;
        }
}