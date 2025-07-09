using System.Linq;
using System.Reflection;
using kOS.Suffixed.PartModuleField;
using kOS.Safe.Encapsulation;

namespace kOS.AddOns.Kerbalism
{
    [kOSAddon("KERBALISM")]
    [kOS.Safe.Utilities.KOSNomenclature("KerbalismAddon")]
    public class Addon : Suffixed.Addon
    {
        static Addon()
        {
            PartModuleFieldsFactory.RegisterConstructionMethod(typeof(KERBALISM.Experiment), (module, shared) => new ExperimentModuleFields(module, shared));
            PartModuleFieldsFactory.RegisterConstructionMethod(typeof(KERBALISM.HardDrive), (module, shared) => new HardDriveModuleFields(module, shared));
        }

        public Addon(SharedObjects shared) : base(shared)
        {}

        public override BooleanValue Available()
        {
            return IsModInstalled("Kerbalism");
        }
        
        private static bool IsModInstalled(string assemblyName)
        {
            Assembly assembly = (from a in AssemblyLoader.loadedAssemblies
                where a.name.ToLower().Equals(assemblyName.ToLower())
                select a).FirstOrDefault().assembly;
            return assembly != null;
        }
    }
}
