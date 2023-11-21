using Microsoft.AspNetCore.Mvc;
using match;
using equipe;
using statistique;

[ApiController]
[Route("api/[controller]")]
public class StatisticsControllers : ControllerBase
{
    string con = "Host=localhost;Port=5432;Username=postgres;Password=prom15;Database=nba;";
    //liste des statistiques pour chaque equipe
    [HttpGet("statistiqueEquipe")]
    public IActionResult getStatistiqueEquipe(int idEquipe)
    {
        Statistique s = new Statistique(con);
        var listeStatistique = s.GetStatistiqueByIdEquipe(idEquipe, con);
        
        return Ok(listeStatistique);
    }

    // liste des equipes
    [HttpGet("listeEquipe")]
    public IActionResult getListeEquipe()
    {
        Equipe e = new Equipe(con);

        var listeEquipe = e.GetAllEquipe(con);

        return Ok(listeEquipe);
    }

    //liste des matchs encours et deja fini
    [HttpGet("listeMatch")]
    public IActionResult getListeMatch()
    {
        Match m = new Match(con);

        var listeMatch = m.GetAllMatch(con);

        return Ok(listeMatch);
    }
}