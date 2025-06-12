using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tp_modul9.Models;

[ApiController]
[Route("api/[controller]")]
public class MahasiswaController : ControllerBase
{
    private static List<Mahasiswa> listMahasiswa = new List<Mahasiswa>
    {
        new Mahasiswa { Nama = "Maria Nathasya", Nim = "2211104008" },
        new Mahasiswa { Nama = "Alfian Mutakim", Nim = "2211104017" },
        new Mahasiswa { Nama = "Nadia Putri Rahmaniar", Nim = "2211104012" },
        new Mahasiswa { Nama = "Muhammad Edgar Nadhif", Nim = "2211104028" },
        new Mahasiswa { Nama = "Muhammad Dhimas Afrizal", Nim = "2211104025" },
    };

    [HttpGet]
    public IEnumerable<Mahasiswa> Get()
    {
        return listMahasiswa;
    }

    [HttpGet("{id}")]
    public ActionResult<Mahasiswa> Get(int id)
    {
        if (id < 0 || id >= listMahasiswa.Count)
            return NotFound();
        return listMahasiswa[id];
    }

    [HttpPost]
    public void Post([FromBody] Mahasiswa mhs)
    {
        listMahasiswa.Add(mhs);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        if (id >= 0 && id < listMahasiswa.Count)
            listMahasiswa.RemoveAt(id);
    }
}
