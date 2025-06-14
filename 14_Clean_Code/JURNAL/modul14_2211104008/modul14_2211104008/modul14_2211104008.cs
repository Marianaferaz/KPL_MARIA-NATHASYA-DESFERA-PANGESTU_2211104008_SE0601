using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tp_modul9.Models;

[ApiController]
[Route("api/[controller]")]
public class MahasiswaController : ControllerBase
{
    private static readonly List<Mahasiswa> MahasiswaList = new List<Mahasiswa>
    {
        new Mahasiswa { Nama = "Maria Nathasya", Nim = "2211104008" },
        new Mahasiswa { Nama = "Alfian Mutakim", Nim = "2211104017" },
        new Mahasiswa { Nama = "Nadia Putri Rahmaniar", Nim = "2211104012" },
        new Mahasiswa { Nama = "Muhammad Edgar Nadhif", Nim = "2211104028" },
        new Mahasiswa { Nama = "Muhammad Dhimas Afrizal", Nim = "2211104025" },
    };

    [HttpGet]
    public ActionResult<IEnumerable<Mahasiswa>> GetAllMahasiswa()
    {
        return Ok(MahasiswaList);
    }

    [HttpGet("{id}")]
    public ActionResult<Mahasiswa> GetMahasiswaById(int id)
    {
        if (!IsValidId(id))
            return NotFound();

        return Ok(MahasiswaList[id]);
    }

    [HttpPost]
    public ActionResult AddMahasiswa([FromBody] Mahasiswa mahasiswa)
    {
        if (mahasiswa == null)
            return BadRequest("Mahasiswa cannot be null.");

        MahasiswaList.Add(mahasiswa);
        return CreatedAtAction(nameof(GetMahasiswaById), new { id = MahasiswaList.Count - 1 }, mahasiswa);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteMahasiswa(int id)
    {
        if (!IsValidId(id))
            return NotFound();

        MahasiswaList.RemoveAt(id);
        return NoContent();
    }

    private bool IsValidId(int id)
    {
        return id >= 0 && id < MahasiswaList.Count;
    }
}
