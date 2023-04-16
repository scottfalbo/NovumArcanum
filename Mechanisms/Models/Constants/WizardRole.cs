///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

namespace Mechanisms.Models.Constants
{
    public static class WizardRole
    {
        /// <summary>
        /// Full permissions in all areas of the site for admin purposes.
        /// Will not be visable or assignable as a role in the admin panel.
        /// </summary>
        public const string MagusArchitect = nameof(MagusArchitect);

        /// <summary>
        /// Full site wide admin permissions. Access to the SecretLair.
        /// </summary>
        public const string MagusPrimus = nameof(MagusPrimus);

        /// <summary>
        /// Permission to update all artist pages.
        /// </summary>
        public const string MagusMagister = nameof(MagusMagister);

        /// <summary>
        /// Permission to update own page.
        /// </summary>
        public const string MagusAdeptus = nameof(MagusAdeptus);

        public static class Id
        {
            public const string MagusArchitect = $"RoleId:{nameof(MagusArchitect)}";
            public const string MagusPrimus = $"RoleId:{nameof(MagusPrimus)}";
            public const string MagusMagister = $"RoleId:{nameof(MagusMagister)}";
            public const string MagusAdeptus = $"RoleId:{nameof(MagusAdeptus)}";
        }
    }
}
