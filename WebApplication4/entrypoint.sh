#!/bin/bash
set -e

echo "Usuwanie bazy danych..."
dotnet ef database drop --force --no-build --yes

echo "Tworzenie bazy danych..."
dotnet ef database update --no-build

echo "Uruchamianie aplikacji..."
exec dotnet WebApplication4.dll