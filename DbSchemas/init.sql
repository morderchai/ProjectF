CREATE TABLE "Users" (
    "Id" uuid primary KEY not null,
    "Username" TEXT not null,
    "Name" TEXT,
    "Surname" TEXT,
    "Email" TEXT not null,
    "Password" TEXT not null,
	"Type" smallint not null,
    primary key ("Id")
);

CREATE TABLE "Destinations" (
    "Id" uuid primary KEY not null,
    "Participants" uuid[] not null,
    "CreationDate" Timestamp not null,
    primary key ("Id")
);

CREATE TABLE "Messages" (
    "Id" uuid primary KEY not null,
    "Text" TEXT not null,
    "SendDate" timestamp not null,
    "AuthorId" TEXT not null,
    "DestinationId" TEXT not null,
    "IsDeleted" boolean,
	"Type" smallint,
    primary key ("Id"),
    constraint fk_authorid foreign key("AuthorId") references "Users"("Id")
);

CREATE TABLE "Threads" (
    "Id" uuid primary KEY not null,
    "Text" TEXT not null,
    "SendDate" timestamp not null,
    "AuthorId" TEXT not null,
    "ReplyId" TEXT,
    primary key ("Id"),
    constraint fk_authorid foreign key("AuthorId") references "Users"("Id")
);

CREATE TABLE "Subthreads" (
    "Id" uuid primary KEY not null,
    "Text" TEXT not null,
    "SendDate" timestamp not null,
    "AuthorId" TEXT not null,
    "ThreadId" TEXT not null,
    primary key ("Id"),
    constraint fk_authorid foreign key("AuthorId") references "Users"("Id"),
    constraint fk_threadid foreign key("ThreadId") references "Threads"("Id") ON DELETE CASCADE
);
