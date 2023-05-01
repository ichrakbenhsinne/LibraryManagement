// Classe Employé
class Employe
{
    private string nom;
    private  int matricule;
    private int indice_salarial;
    private float salaire;
    

    public Employe(string nom, int matricule, int indice_salarial, float salaire)
    {
        this.nom = nom;
        this.matricule = matricule;
        this.indice_salarial = indice_salarial;
        this.salaire = salaire;
    }
    public string getNom()
    { return nom; }

    public void AfficherCaracteristiques()
    {
        Console.WriteLine("Nom : " + nom);
        Console.WriteLine("Matricule : " + matricule);
        Console.WriteLine("Indice salarial : " + indice_salarial);
    }

    public float CalculerSalaire()
    {
        return indice_salarial * salaire;
    }

   public void setValRef(int val)
    {
        indice_salarial = val;
    }
}

// Sous-classe Responsable
class Responsable : Employe
{
    private List<Employe> subordonnes;

    public Responsable(string nom, int matricule, int indice_salarial, float salaire)
        : base(nom, matricule, indice_salarial,salaire)
    {
        subordonnes = new List<Employe>();

    }

    public void AjouterSubordonne(Employe employe)
    {
        subordonnes.Add(employe);
    }

    public void AfficherSubordonnesDirects()
    {
        Console.WriteLine("Subordonnés directs :");
        foreach (Employe employe in subordonnes)
        {
            Console.WriteLine("\t" + employe.getNom());
        }
    }

    public void AfficherTousLesSubordonnes()
    {
        Console.WriteLine("Subordonnés directs :");
        foreach (Employe employe in subordonnes)
        {
            Console.WriteLine("\t" + employe.getNom());
            if (employe is Responsable)
            {
                ((Responsable)employe).AfficherTousLesSubordonnes();
            }
        }
    }
}

// Sous-classe Commercial
class Commercial : Employe
{
    private int ventes_mois_precedent;

    public Commercial(string nom, int matricule, int indice_salarial, int ventes_mois_precedent, float salaire)
        : base(nom, matricule, indice_salarial, salaire)
    {
        this.ventes_mois_precedent = ventes_mois_precedent;
    }

    public void MettreAJourVentes(int ventes)
    {
        ventes_mois_precedent = ventes;
    }

    public new float CalculerSalaire()
    {
        float salaire_base = base.CalculerSalaire();
        return salaire_base + (ventes_mois_precedent);
    }
}
 class Program
{
    static void Main(string[] args)
    {
        System.Collections.Generic.List<Employe> employes = new System.Collections.Generic.List<Employe>();
        employes.Add(new Responsable('molka', 1234, 4, 500));
        employes.Add(new Commercial('ichrak', 1234, 4,7, 1000));

    }
    

}
