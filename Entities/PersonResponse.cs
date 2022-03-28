namespace WingsCredentialsApproval
{
    public class PersonResponse
    {
        private string foreignCompany;
        private string corporateSize;
        private string taxRegime;
        private string segment;
        private Nature nature;
        private string specialSituationAtFederalRevenue;
        private string id;
        private string type;
        private string nickname;
        private string name;
        private string abbreviatedName;
        private string documentNumber;
        private string createdAt;
        private string cadastralSituationAtFederalRevenue;
        private string preRegistration;

        public string ForeignCompany { get => foreignCompany; set => foreignCompany = value; }
        public string CorporateSize { get => corporateSize; set => corporateSize = value; }
        public string TaxRegime { get => taxRegime; set => taxRegime = value; }
        public string Segment { get => segment; set => segment = value; }
        public Nature Nature { get => nature; set => nature = value; }
        public string SpecialSituationAtFederalRevenue { get => specialSituationAtFederalRevenue; set => specialSituationAtFederalRevenue = value; }
        public string Id { get => id; set => id = value; }
        public string Type { get => type; set => type = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public string Name { get => name; set => name = value; }
        public string AbbreviatedName { get => abbreviatedName; set => abbreviatedName = value; }
        public string DocumentNumber { get => documentNumber; set => documentNumber = value; }
        public string CreatedAt { get => createdAt; set => createdAt = value; }
        public string CadastralSituationAtFederalRevenue { get => cadastralSituationAtFederalRevenue; set => cadastralSituationAtFederalRevenue = value; }
        public string PreRegistration { get => preRegistration; set => preRegistration = value; }
    }
}