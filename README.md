# kOS/Kerbalism Bridge

This provides a custom kOS addon to enable working with Kerbalism experiments from scripts.

## Installation

* Copy `GameData/Kerbalism/Kerbalism112.kbin` to `GameData/Kerbalism/Kerbalism.dll` in your KSP installation.
  * If you know how to make this mod depend lazily on Kerbalism so that the kerbalism loader will work right,
    please let me know!
* Copy `GameData/kos_kerbalism` to your KSP installation

You can confirm the mod is installed correctly in kOS with `print ADDONS:AVAILABLE("KERBALISM").`

## Usage

The following custom suffixes are added to kerbalism module types

### `ExperimentModule`

* `DEPLETED` - returns `true` if this experiment has a limited sample size and it has been used
  up. Never returns `true` for experiments which collect their samples from the environment. This
  will return `true` even in cases when the kerbalism PAW might prefer to show a different error
  before checking the depleted status.

### `HardDrive`

* `TRANSFERHERE()` - Equivalent to pressing the "transfer here" button in the PAW