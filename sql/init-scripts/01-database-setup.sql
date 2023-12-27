CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- Create CalendarEvent table
CREATE TABLE "calendarEvent" (
    "id" uuid DEFAULT uuid_generate_v4() PRIMARY KEY,
    "dateAndTime" TIMESTAMP NOT NULL,
    "title" VARCHAR(255) NOT NULL,
    "location" VARCHAR(255) NOT NULL,
    "status" VARCHAR(50) NOT NULL
);


-- Create Person table
CREATE TABLE "person" (
    "id" uuid DEFAULT uuid_generate_v4() PRIMARY KEY,
    "firstname" VARCHAR(255) NOT NULL,
    "lastname" VARCHAR(255) NOT NULL,
    "email" VARCHAR(255) NOT NULL
);

-- Create participant table
CREATE TABLE "participant" (
    "calendarEventId" uuid NOT NULL,
    "personId" uuid NOT NULL,
    PRIMARY KEY ("calendarEventId", "personId"),
    FOREIGN KEY ("calendarEventId") REFERENCES "calendarEvent" ("id") ON DELETE CASCADE,
    FOREIGN KEY ("personId") REFERENCES "person" ("id") ON DELETE CASCADE
);
