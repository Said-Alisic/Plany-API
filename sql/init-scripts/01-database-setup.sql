CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- Create theme enum type
CREATE TYPE themeEnum AS ENUM ('SYSTEM', 'DARK', 'LIGHT');

-- Create users table
CREATE TABLE
	"users" (
		"id" uuid DEFAULT uuid_generate_v4 () PRIMARY KEY,
		"firstname" VARCHAR(255) NOT NULL,
		"lastname" VARCHAR(255) NOT NULL,
		"email" VARCHAR(255) NOT NULL,
		"password" VARCHAR(100) NOT NULL,
		"theme" themeEnum NOT NULL DEFAULT 'SYSTEM',
		"notificationsEnabled" BOOLEAN NOT NULL DEFAULT true,
		"createdAt" TIMESTAMP NOT NULL DEFAULT NOW (),
		"updatedAt" TIMESTAMP NOT NULL DEFAULT NOW ()
	);

-- Create calendarEvents table
CREATE TABLE
	"calendarEvents" (
		"id" uuid DEFAULT uuid_generate_v4 () PRIMARY KEY,
		"dateAndTime" TIMESTAMP NOT NULL,
		"title" VARCHAR(255) NOT NULL,
		"location" VARCHAR(255) NOT NULL,
		"status" VARCHAR(50) NOT NULL,
		"description" VARCHAR(500),
		"createdAt" TIMESTAMP NOT NULL DEFAULT NOW (),
		"updatedAt" TIMESTAMP NOT NULL DEFAULT NOW ()
	);

-- Create participants table
CREATE TABLE
	"participants" (
		"calendarEventId" uuid NOT NULL,
		"userId" uuid NOT NULL,
		"createdAt" TIMESTAMP NOT NULL DEFAULT NOW (),
		"updatedAt" TIMESTAMP NOT NULL DEFAULT NOW (),
		PRIMARY KEY ("calendarEventId", "userId"),
		FOREIGN KEY ("calendarEventId") REFERENCES "calendarEvents" ("id") ON DELETE CASCADE,
		FOREIGN KEY ("userId") REFERENCES "users" ("id") ON DELETE CASCADE
	);