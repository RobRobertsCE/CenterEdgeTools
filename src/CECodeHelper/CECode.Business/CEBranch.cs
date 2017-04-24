namespace CECode.Business
{
    internal class CEBranch : ICEBranch
    {
        #region properties
        public string Name { get; set; }
        public string RepositoryName { get; set; }
        public string Sha { get; set; } 
        #endregion
    }
}
