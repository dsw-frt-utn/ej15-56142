using Dsw2026Ej15.Data.Dtos;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;
using System.Numerics;
using System.Text.Json;

public class PersistenceInMemory : IPersistence
{
    private List<Speciality> _specialities = [];
    private List<Doctor> _doctors = [];

    public PersistenceInMemory()
    {
        LoadSpecialities();
    }

    public void SaveDoctor(Doctor doctor)
    {
        _doctors.Add(doctor);
    }

    public Speciality? GetSpecialityById(Guid id)
    {
        return _specialities.FirstOrDefault(e => e.Id == id);
    }

    private void LoadSpecialities()
    {
        try
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "Sources", "specialities.json");
            var json = File.ReadAllText(jsonPath);
            var specialities = JsonSerializer.Deserialize<List<SpecialityDto>>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? [];
            _specialities = [.. specialities.Select(s => new Speciality(s.Name, s.Description, s.Id))];
        }
        catch (Exception)
        {

        }
    }

    public void AddDoctor(Doctor doctor)
    {
        throw new NotImplementedException();
    }
}