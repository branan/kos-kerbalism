using kOS.Safe.Encapsulation.Suffixes;
using kOS.Safe.Utilities;
using kOS.Suffixed.PartModuleField;

namespace kOS.AddOns.Kerbalism
{
    [KOSNomenclature("HardDriveModule")]
    public class HardDriveModuleFields: PartModuleFields
    {
        private readonly KERBALISM.HardDrive _module;

        public HardDriveModuleFields(PartModule module, SharedObjects shared) : base(module, shared)
        {
            _module = (KERBALISM.HardDrive)module;
            RegisterInitializer(InitializeSuffixes);
        }

        private void InitializeSuffixes()
        {
            AddSuffix("TRANSFERHERE", new NoArgsVoidSuffix(() => TransferData()));
        }

        private void TransferData()
        {
            var prevActive = _module.Events["TransferData"].active;
            _module.Events["TransferData"].active = true;
            _module.TransferData();
            _module.Events["TransferData"].active = prevActive;
        }
    }
}
