/* create questions table with view to secure tenant */
CREATE TABLE IF NOT EXISTS tenant (
	id uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
	name CITEXT NOT NULL
);
GRANT SELECT, INSERT, UPDATE, DELETE ON tenant TO tenant_admin;

CREATE TABLE IF NOT EXISTS t_questions (
	id uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
	question_text CITEXT NOT NULL,
	tenant VARCHAR ( 20 ) NOT NULL DEFAULT current_user
);

CREATE OR REPLACE VIEW questions AS
    SELECT
        id,
        question_text
    FROM
        t_questions
    WHERE
        tenant = current_user;

GRANT SELECT, INSERT, UPDATE, DELETE ON questions TO tenant_user;
