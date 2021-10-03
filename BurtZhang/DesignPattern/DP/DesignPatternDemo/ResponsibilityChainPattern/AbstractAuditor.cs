namespace ResponsibilityChainPattern
{
    public abstract class AbstractAuditor
    {
        public string Name { get; set; }
        public abstract void Audit(ApplyContext context);

        protected AbstractAuditor _auditor = null;


        public AbstractAuditor SetNext(AbstractAuditor auditor)
        {
            _auditor = auditor;
            return this;
        }
    }
}