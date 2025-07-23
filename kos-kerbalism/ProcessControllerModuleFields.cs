using System.Runtime.InteropServices;
using kOS.Safe.Encapsulation;
using kOS.Safe.Encapsulation.Suffixes;
using kOS.Safe.Utilities;
using kOS.Suffixed.PartModuleField;
using KSP.UI.Screens.Settings.Controls;

namespace kOS.AddOns.Kerbalism
{
    [KOSNomenclature("ProcessControllerModule")]
    public class ProcessControllerModuleFields: PartModuleFields
    {
        private readonly KERBALISM.ProcessController _module;

        public ProcessControllerModuleFields(PartModule module, SharedObjects shared) : base(module, shared)
        {
            _module = (KERBALISM.ProcessController)module;
            RegisterInitializer(InitializeSuffixes);
        }

        private void InitializeSuffixes()
        {
            AddSuffix("START", new NoArgsVoidSuffix(() => Start()));
            AddSuffix("STOP", new NoArgsVoidSuffix(() => Stop()));
            AddSuffix("BROKEN", new NoArgsSuffix<BooleanValue>(() => Broken()));
            AddSuffix("RUNNING", new NoArgsSuffix<BooleanValue>(() => Running()));
            AddSuffix("ACTIVE", new NoArgsSuffix<BooleanValue>(() => Active()));
            AddSuffix("TITLE", new NoArgsSuffix<StringValue>(() => Title()));
        }

        private void Start()
        {
            _module.SetRunning(true);
        }

        private void Stop()
        {
            _module.SetRunning(false);
        }

        private bool Broken()
        {
            if (_module.IsRunning())
            {
                return !_module.ModuleIsActive();
            }
            else
            {
                Start();
                var broken = !_module.ModuleIsActive();
                Stop();
                return broken;
            }
        }

        private bool Running()
        {
            return _module.IsRunning();
        }

        private bool Active()
        {
            return _module.ModuleIsActive();
        }

        private string Title()
        {
            return _module.title;
        }
    }
}