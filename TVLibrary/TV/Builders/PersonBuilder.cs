using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TVLibrary.TV.Builders;

public class PersonBuilder
{
    int id;
    string? url;
    string? name;
    Country? country;
    DateOnly birthday;
    string? gender;
    Image? image;

    // Check Person.cs for more info!!
    bool isDead = false;
    DateOnly deathday;

    public PersonBuilder BuildId(int id)
    {
        this.id = id;
        return this;
    }

    public PersonBuilder BuildUrl(string url) 
    {
        this.url = url;
        return this;
    }

    public PersonBuilder BuildName(string name) 
    {
        this.name = name;
        return this;
    }

    public PersonBuilder BuildCountry(Country country) 
    {
        this.country = country;
        return this;
    }

    public PersonBuilder BuildImage(Image image) 
    {
        this.image = image;
        return this;
    }

    public PersonBuilder BuildBirthday(DateOnly birthday)
    {
        this.birthday = birthday;
        return this;
    }

    public PersonBuilder BuildGender(string gender) 
    {
        this.gender = gender;
        return this;
    }

    // check Person.cs for more info!!
    public PersonBuilder BuildDeathday(bool isDead, DateOnly deathday)
    {
        this.deathday = deathday;
        this.isDead = isDead;
        return this;
    }

    public Person Build()
    {
        if (!HasZeroNullParameters())
            throw new InvalidOperationException("Attempted to build, while there was a null value!");

        // check Person.cs for more info!!
        if (isDead) 
            return new(id, url!, name!, country!, birthday, deathday, gender!, image!);
        return new(id, url!, name!, country!, birthday, gender!, image!);
    }

    bool HasZeroNullParameters()
    {
        return (url is not null) &&
            (name is not null) &&
            (country is not null) &&
            (image is not null);
    }
}
