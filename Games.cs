class Games
    {
    public string Cim {  get; set; }
    public string Mufaj { get; set; }
    public DateTime KiadasDatum { get; set; }
    public int AktivJatekosok {  get; set; }
    public double Ertekeles {  get; set; }

    public override string ToString() =>
        $"\tCím: {Cim}\n" +
        $"\tMufaj: {Mufaj}\n" +
        $"\tKiadás dátuma: {KiadasDatum}\n" +
        $"\tAktív játékosok: {AktivJatekosok}\n" +
        $"\tÉrtékelés: {Ertekeles:0.0}\n";
    }
