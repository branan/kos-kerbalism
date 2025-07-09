using kOS.Safe.Encapsulation;
using kOS.Safe.Encapsulation.Suffixes;
using kOS.Safe.Utilities;
using kOS.Suffixed.PartModuleField;

namespace kOS.AddOns.Kerbalism
{
    [KOSNomenclature("ExperimentModule")]
    public class ExperimentModuleFields: PartModuleFields
    {
        private readonly KERBALISM.Experiment _module;

        public ExperimentModuleFields(PartModule module, SharedObjects shared) : base(module, shared)
        {
            _module = (KERBALISM.Experiment)module;
            RegisterInitializer(InitializeSuffixes);
        }

        private void InitializeSuffixes()
        {
            AddSuffix("DEPLETED", new NoArgsSuffix<BooleanValue>(() => IsDepleted()));
        }

        private bool IsDepleted()
        {
            return !_module.sample_collecting && _module.remainingSampleMass <= 0.0 && _module.ExpInfo.SampleMass > 0.0;
        }
    }
}
