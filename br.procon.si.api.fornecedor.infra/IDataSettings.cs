namespace br.procon.si.api.fornecedor.infra
{
    public interface IDataSettings
    {
        string DefaultConnection { get; set; }
        int? commandTimeout {get;set;}
    }   
}