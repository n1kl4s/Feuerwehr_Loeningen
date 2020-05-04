namespace Backend.Enum
{
    /// <summary>
    /// Die Rollenverteilung im System
    /// </summary>
    public enum Role
    {
        /// <summary>
        /// Godmode, dieser benutzer hat keinerlei Einschrenkungen
        /// </summary>
        God = 1,

        /// <summary>
        /// Admin: Darf einsätze und Fahrzeuge Pflegen, sowie Mitarbeiter hinzufügen
        /// </summary>
        Admin = 2,
        
        /// <summary>
        /// Benutzer, darf in geschützte Bereiche eintreten
        /// </summary>
        Member = 4,

        /// <summary>
        /// Gast darf öffentliche Bereiche einsehen
        /// </summary>
        Guest = 10
    }
}
