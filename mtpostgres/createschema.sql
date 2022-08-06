/* create questions table with view to secure tenant */
CREATE TABLE IF NOT EXISTS t_questions (
	id uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
	question_text CITEXT NOT NULL,
	tenant VARCHAR ( 20 ) NOT NULL DEFAULT current_user
);

CREATE VIEW questions AS
    SELECT
        id,
        question_text
    FROM
        t_questions
    WHERE
        tenant = current_user;

GRANT SELECT, INSERT ON questions TO tenant_user;
