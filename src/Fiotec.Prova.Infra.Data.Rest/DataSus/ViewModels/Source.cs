using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Prova.Infra.Data.Rest.DataSus.ViewModels
{
    public class Source
    {
        public string vacina_grupoAtendimento_nome { get; set; }
        public string vacina_codigo { get; set; }
        public string paciente_dataNascimento { get; set; }
        public string ds_condicao_maternal { get; set; }
        public string paciente_endereco_nmPais { get; set; }
        public string paciente_racaCor_valor { get; set; }
        public string sistema_origem { get; set; }
        public string paciente_id { get; set; }
        public string paciente_endereco_uf { get; set; }
        public int paciente_idade { get; set; }
        public string paciente_endereco_cep { get; set; }
        public string estabelecimento_valor { get; set; }
        public string estabelecimento_municipio_codigo { get; set; }
        public DateTime data_importacao_datalake { get; set; }
        public string paciente_enumSexoBiologico { get; set; }
        public string estabelecimento_municipio_nome { get; set; }
        public string vacina_grupoAtendimento_codigo { get; set; }
        public string vacina_descricao_dose { get; set; }
        public string paciente_endereco_nmMunicipio { get; set; }
        public string vacina_categoria_nome { get; set; }
        public string vacina_fabricante_nome { get; set; }
        public string vacina_categoria_codigo { get; set; }
        public object dt_deleted { get; set; }
        public string paciente_nacionalidade_enumNacionalidade { get; set; }
        public string vacina_numDose { get; set; }
        public string status { get; set; }
        public string document_id { get; set; }
        public string vacina_lote { get; set; }
        public string id_sistema_origem { get; set; }

        [JsonProperty("@timestamp")]
        public DateTime timestamp { get; set; }
        public string estalecimento_noFantasia { get; set; }

        [JsonProperty("@version")]
        public string version { get; set; }
        public string paciente_racaCor_codigo { get; set; }
        public string estabelecimento_razaoSocial { get; set; }
        public string vacina_nome { get; set; }
        public string estabelecimento_uf { get; set; }
        public DateTime data_importacao_rnds { get; set; }
        public DateTime vacina_dataAplicacao { get; set; }
        public int? co_condicao_maternal { get; set; }
        public string paciente_endereco_coPais { get; set; }
        public string vacina_fabricante_referencia { get; set; }
        public string paciente_endereco_coIbgeMunicipio { get; set; }
    }
}
