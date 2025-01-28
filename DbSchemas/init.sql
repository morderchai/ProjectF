CREATE TABLE "Users" (
    "Id" uuid primary KEY,
    "Username" TEXT,
    "Name" TEXT,
    "Surname" TEXT,
    "Email" TEXT,
    "Password" TEXT,
	"Type" smallint
);

CREATE TABLE "Destinations" (
    "Id" uuid primary KEY,
    "Participants" uuid[],
    "CreationDate" Timestamp
);

CREATE TABLE "Messages" (
    "Id" uuid primary KEY,
    "Text" TEXT,
    "SendDate" timestamp,
    "AuthorId" TEXT,
    "DestinationId" TEXT,
    "IsDeleted" boolean,
	"Type" smallint
);