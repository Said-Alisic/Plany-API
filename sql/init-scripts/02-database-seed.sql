-- Insert CalendarEvent seed data
INSERT INTO "calendarEvent" ("id", "dateAndTime", "title", "location", "status")
VALUES
  ('407714b2-6d85-4d71-b23a-d4d6609ffab7', '2023-01-01 08:00:00', 'Event 1', 'Location 1', 'ACTIVE'),
  ('91e42a53-d6a3-40a7-bebc-7eb91e1e36cd', '2023-02-02 12:30:00', 'Event 2', 'Location 2', 'COMPLETED'),
  ('3f09e571-2a8c-417b-8a90-949fc9324384', '2023-03-03 18:45:00', 'Event 3', 'Location 3', 'CANCELLED'),
  ('7dd2bc7d-1f68-4a0c-8598-151b53ff8682', '2023-04-04 10:15:00', 'Event 4', 'Location 4', 'ACTIVE'),
  ('096c6f54-2219-4678-a845-4dc997c3bcf6', '2023-05-05 15:20:00', 'Event 5', 'Location 5', 'COMPLETED'),
  ('05301ead-67a1-4918-a646-9269f87952bd', '2023-06-06 21:00:00', 'Event 6', 'Location 6', 'CANCELLED'),
  ('bd7a653b-380a-450b-8032-f2451c30005f', '2023-07-07 09:45:00', 'Event 7', 'Location 7', 'ACTIVE'),
  ('b628edd9-7683-4d0b-931b-4f2efe916cfb', '2023-08-08 14:10:00', 'Event 8', 'Location 8', 'COMPLETED'),
  ('998aed01-90b8-40cf-9864-6ae18b4430e0', '2023-09-09 19:30:00', 'Event 9', 'Location 9', 'CANCELLED'),
  ('e3226c40-5828-4e0b-a5de-272c6396ddc2', '2023-10-10 11:20:00', 'Event 10', 'Location 10', 'ACTIVE'),
  ('e79a5271-79bc-47cb-bd90-ffa9d0e8a0b4', '2023-11-11 13:45:00', 'Event 11', 'Location 11', 'COMPLETED'),
  ('1359d725-bef8-4aa2-a3dd-7e85ff2a5f8d', '2023-12-12 22:00:00', 'Event 12', 'Location 12', 'CANCELLED'),
  ('88fc1822-655c-4297-b190-cf4d5a75c005', '2024-01-01 08:30:00', 'Event 13', 'Location 13', 'ACTIVE'),
  ('b6c33925-3565-48be-b5e8-eae3b25a1256', '2024-02-02 14:05:00', 'Event 14', 'Location 14', 'COMPLETED'),
  ('206f10f1-701a-4037-80f2-1b51eafd1801', '2024-03-03 20:15:00', 'Event 15', 'Location 15', 'CANCELLED'),
  ('6590c8cc-a532-49e4-ac0f-244b2a1b056f', '2024-04-04 10:45:00', 'Event 16', 'Location 16', 'ACTIVE'),
  ('b771ae7e-7768-40f4-89cb-1a880bd0a63d', '2024-05-05 16:30:00', 'Event 17', 'Location 17', 'COMPLETED'),
  ('57236a59-5e12-44e0-893a-c0a5c957ff8d', '2024-06-06 18:55:00', 'Event 18', 'Location 18', 'CANCELLED'),
  ('3e06c69e-ac9d-4c62-955c-d61dc9856bdb', '2024-07-07 09:00:00', 'Event 19', 'Location 19', 'ACTIVE'),
  ('d0136348-63d6-41be-96db-6e95fd8e345b', '2024-08-08 15:40:00', 'Event 20', 'Location 20', 'COMPLETED');



-- Insert Person seed data
INSERT INTO "person" ("id", "firstname", "lastname", "email")
VALUES
  ('39bf5de4-4049-4463-bdbb-007d2ee02474', 'John', 'Doe', 'john.doe@example.com'),
  ('d1aef966-6661-4959-8d53-957265ee04a0', 'Jane', 'Doe', 'jane.doe@example.com'),
  ('7777c377-4dd6-4346-8f52-75a96992f078', 'Alice', 'Smith', 'alice.smith@example.com'),
  ('3a84c478-24dd-4bba-9fae-fee48788c35f', 'Bob', 'Johnson', 'bob.johnson@example.com'),
  ('9e9ebd4e-7224-4c08-8d1a-d42b3fb367e2', 'Emily', 'Williams', 'emily.williams@example.com'),
  ('94a9a324-d827-4b90-88b6-90dc62d3d5ce', 'Michael', 'Brown', 'michael.brown@example.com'),
  ('7d0879a0-d33e-4925-a98c-128c5f8f7cef', 'Sophia', 'Jones', 'sophia.jones@example.com'),
  ('4499c71a-83e2-4413-8eb6-d64038f1cf99', 'David', 'Taylor', 'david.taylor@example.com'),
  ('026bc1e8-2c93-4d4c-8f1f-4de64b3fbfc2', 'Olivia', 'Martinez', 'olivia.martinez@example.com'),
  ('3294cc62-9b9e-4330-af3b-d9060320e4a1', 'Daniel', 'Anderson', 'daniel.anderson@example.com'),
  ('7e48612c-19fc-4ccc-9651-2782e4a9a1f5', 'Emma', 'Thomas', 'emma.thomas@example.com'),
  ('d1adfbf6-06f1-4016-90aa-5dccdd41fb89', 'Christopher', 'Harris', 'christopher.harris@example.com'),
  ('ff6ba20e-0900-4c15-a39e-6baab5d2d8a4', 'Ava', 'Clark', 'ava.clark@example.com'),
  ('58d65c8b-3fd1-4738-b863-4a7b4abf74d3', 'Matthew', 'Lewis', 'matthew.lewis@example.com'),
  ('bee967a7-0c2a-44f8-8044-d73f588a2c02', 'Madison', 'Moore', 'madison.moore@example.com'),
  ('fa0f4d15-1a42-4bfd-a315-a3e59249367a', 'Ethan', 'White', 'ethan.white@example.com'),
  ('63017c5e-f2d1-4719-a3b9-3bc6917020d7', 'Sophie', 'Scott', 'sophie.scott@example.com'),
  ('ab252f7d-ac3e-4db3-9d4d-a184fe337d7c', 'Justin', 'King', 'justin.king@example.com'),
  ('dbc820cc-1fae-48fd-987d-043050c8028c', 'Victoria', 'Young', 'victoria.young@example.com'),
  ('3129e20f-484a-4c55-b482-8d7e9d30ede5', 'William', 'Hill', 'william.hill@example.com'),
  ('ec45a75d-8bb2-4149-ad05-03b07e0efa9e', 'Isabella', 'Miller', 'isabella.miller@example.com'),
  ('338ab2d0-9e09-41a5-a423-98b6c6cc468c', 'James', 'Allen', 'james.allen@example.com');


-- Insert Participant seed data
INSERT INTO "participant" ("calendarEventId", "personId")
VALUES
  ('407714b2-6d85-4d71-b23a-d4d6609ffab7', '39bf5de4-4049-4463-bdbb-007d2ee02474'),
  ('407714b2-6d85-4d71-b23a-d4d6609ffab7', '4499c71a-83e2-4413-8eb6-d64038f1cf99'),
  ('6590c8cc-a532-49e4-ac0f-244b2a1b056f', '3129e20f-484a-4c55-b482-8d7e9d30ede5'),
  ('91e42a53-d6a3-40a7-bebc-7eb91e1e36cd', '3129e20f-484a-4c55-b482-8d7e9d30ede5'),
  ('407714b2-6d85-4d71-b23a-d4d6609ffab7', '7e48612c-19fc-4ccc-9651-2782e4a9a1f5'),
  ('6590c8cc-a532-49e4-ac0f-244b2a1b056f', '7e48612c-19fc-4ccc-9651-2782e4a9a1f5'),
  ('d0136348-63d6-41be-96db-6e95fd8e345b', '7e48612c-19fc-4ccc-9651-2782e4a9a1f5'),
  ('407714b2-6d85-4d71-b23a-d4d6609ffab7', '7d0879a0-d33e-4925-a98c-128c5f8f7cef'),
  ('d0136348-63d6-41be-96db-6e95fd8e345b', 'bee967a7-0c2a-44f8-8044-d73f588a2c02'),
  ('05301ead-67a1-4918-a646-9269f87952bd', 'bee967a7-0c2a-44f8-8044-d73f588a2c02'),
  ('407714b2-6d85-4d71-b23a-d4d6609ffab7', '9e9ebd4e-7224-4c08-8d1a-d42b3fb367e2'),
  ('e3226c40-5828-4e0b-a5de-272c6396ddc2', 'bee967a7-0c2a-44f8-8044-d73f588a2c02'),
  ('91e42a53-d6a3-40a7-bebc-7eb91e1e36cd', 'bee967a7-0c2a-44f8-8044-d73f588a2c02'),
  ('407714b2-6d85-4d71-b23a-d4d6609ffab7', 'dbc820cc-1fae-48fd-987d-043050c8028c'),
  ('05301ead-67a1-4918-a646-9269f87952bd', '026bc1e8-2c93-4d4c-8f1f-4de64b3fbfc2'),
  ('91e42a53-d6a3-40a7-bebc-7eb91e1e36cd', '026bc1e8-2c93-4d4c-8f1f-4de64b3fbfc2'),
  ('407714b2-6d85-4d71-b23a-d4d6609ffab7', 'bee967a7-0c2a-44f8-8044-d73f588a2c02'),
  ('05301ead-67a1-4918-a646-9269f87952bd', '338ab2d0-9e09-41a5-a423-98b6c6cc468c'),
  ('206f10f1-701a-4037-80f2-1b51eafd1801', '026bc1e8-2c93-4d4c-8f1f-4de64b3fbfc2'),
  ('407714b2-6d85-4d71-b23a-d4d6609ffab7', '026bc1e8-2c93-4d4c-8f1f-4de64b3fbfc2'),
  ('407714b2-6d85-4d71-b23a-d4d6609ffab7', 'ec45a75d-8bb2-4149-ad05-03b07e0efa9e'),
  ('6590c8cc-a532-49e4-ac0f-244b2a1b056f', 'ec45a75d-8bb2-4149-ad05-03b07e0efa9e'),
  ('407714b2-6d85-4d71-b23a-d4d6609ffab7', 'd1aef966-6661-4959-8d53-957265ee04a0');