namespace DataLayer
{
    public class TCompany
    {
        public TCompany() { }
        public string Cname{ get; set; }
        public string CType{get;set; }
        public string startdate { get; set; }
        public string enddate { get; set; }

        public override string ToString()
        {
            return $"\nCompany Name: {Cname}nTitle: {CType} Year: {startdate}\nEnd Year: {enddate}\n";
        }
    }
}
