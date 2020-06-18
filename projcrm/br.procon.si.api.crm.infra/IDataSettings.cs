namespace br.procon.si.api.crm.infra
{
    public interface IDataSettings
    {
        string DefaultConnection { get; set; }
        int? commandTimeout {get;set;}
    }   
}