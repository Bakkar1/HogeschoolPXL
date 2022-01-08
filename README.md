# HogeschoolPXL

<div class="container">
        <div class="card">
            <div class="card-header">
                Project intializeren
            </div>
            <div class="card-body">
                <blockquote class="blockquote mb-0">
                    <p>Nuget Package instaleren :</p>
                    <ul>
                        <li>Microsoft.EntityFrameworkCore.SqlServer</li>
                        <li>Microsoft.EntityFrameworkCore.Tools</li>
                    </ul>
                    <p>Class AppDbContext aanmaken</p>
                </blockquote>
            </div>
        </div>
        <div class="card">
            <div class="card-header">
                Models
            </div>
            <div class="card-body">
                <blockquote class="blockquote mb-0">
                    <p>klassen aanmaken </p>
                    <ul>
                        <li>Gebruiker</li>
                        <li>Vak</li>
                        <li>Handboek</li>
                        <li>Lector</li>
                        <li>VakLector</li>
                        <li>Student</li>
                        <li>Inschrijvingen</li>
                        <li>Academiejaar</li>
                    </ul>
                    <p>Relaties tussen de klassen toevoegen</p>
                    <p>Model Validation toevoegen</p>
                </blockquote>
            </div>
        </div>
        <div class="card">
            <div class="card-header">
                Servies
            </div>
            <div class="card-body">
                <blockquote class="blockquote mb-0">
                    <p>mijn servies aanmaken :</p>
                    <ul>
                        <li>IPxl interface Creëren</li>
                        <li>PartialSQLPxlRepository class creëren voor implementeren van de interface</li>
                        <li>Registreer de service in startup.cs</li>
                    </ul>
                </blockquote>
            </div>
        </div>
        <div class="card">
            <div class="card-header">
                Controllers & Views
            </div>
            <div class="card-body">
                <blockquote class="blockquote mb-0">
                    <ul>
                        <li>Scaffold alle controllers met hen views</li>
                        <li>Views styling met bootstrap en css stylesheet</li>
                        <li>Gbruik maken van TagHelpers, View Component en Partial View om de code leesbaar en eenvoudiger  te maken</li>
                        <li>Ipxl interface injection in alle controllers in plaats van de AppDbContext</li>
                    </ul>
                </blockquote>
            </div>
        </div>
        <div class="card">
            <div class="card-header">
                Data
            </div>
            <div class="card-body">
                <blockquote class="blockquote mb-0">
                    <ul>
                        <li>ConnectionString aanmaken in appsettings.json</li>
                        <li>ConnectionString toevoegen in startup.cs</li>
                        <li>Seed Data class toevoegen om een initial data te hebben</li>
                        <li>Add migration</li>
                    </ul>
                </blockquote>
            </div>
        </div>
        <div class="card">
            <div class="card-header">
                Identity Framework
            </div>
            <div class="card-body">
                <blockquote class="blockquote mb-0">
                    <ul>
                        <li>Project aanpassen om Identity framework te kunnen gebruiken</li>
                        <li>Zoekfunctie toevoegen in Studenten view en Lectoren view</li>
                        <li>Gebruiker aanpassen naar custom Identity User om de applicatie beter te beveiligen</li>
                        <li>SeedDataIdentity class toevoegen om initial data te hebben</li>
                        <li>Roles binnen de applicatie bepalen zodat de applicatie zich aanpast afhankelijk van de gebruiker role</li>
                    </ul>
                </blockquote>
            </div>
        </div>
    </div>
</div>