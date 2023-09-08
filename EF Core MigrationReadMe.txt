			**EF Core Migration Procedure**
NOTE: Migration files will be missing after cloning, therefore you have to run Migration and update the database.

To Add Migration
1. Open Solution C:\Users\Paa Kwasi\Desktop\StringTranslaterProject\StringTranslator\StringConverter.sln
2. Open Migration Folder.
3. Delete the Migration files '20230904155824_InitialMigration' and 'StringConverterDbContextModelSnapshot' respectively.
4. Open appsettings.json, change connection string for "StringConverterConnectionString": "Server=DESKTOP-OOBUVHM\\SQLEXPRESS;Database=TranslatorDb;Trusted_Connection=True;TrustServerCertificate=Yes" to your local server/database connection.
5. Change only the server name for "StringConverterContextConnection": "Server=DESKTOP-OOBUVHM\\SQLEXPRESS;Database=StringConverter;Trusted_Connection=True;MultipleActiveResultSets=true"
6. Go to 'Package Manager' console, make sure default project is 'StringConverter'.
7. Type Add-Migration "Migration Name" eg; Add-Migration InitialMigration.
8. After successfully executing, type "Update Database".
9. Execute the solution