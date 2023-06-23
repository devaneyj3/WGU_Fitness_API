const CLIENTS = "clients";
const INSTRUCTORS = "instructors";
const FITNESS_CLASSES = "fitness_classes";
const CLIENTS_CLASSES = "clients_classes";

const CLIENTS_TABLE = {
	ID: "id",
	NAME: "name",
	EMAIL: "email",
	PHONE: "phone",
	USERNAME: "username",
	PASSWORD: "password",
};

const INSTRUCTORS_TABLE = {
	ID: "id",
	NAME: "name",
	EMAIL: "email",
	PHONE: "phone",
	USERNAME: "username",
	PASSWORD: "password",
};

const FITNESS_CLASSES_TABLE = {
	ID: "id",
	NAME: "name",
	LOCATION: "location",
	DETAILS: "details",
	INSTRUCTOR_NAME: "instructorname",
	INSTRUCTOR_EMAIL: "instructoremail",
	INSTRUCTOR_PHONE: "instructorphone",
	START_TIME: "start_time",
	END_TIME: "end_time",
	ENROLLMENT: "enrollment",
	CAPACITY: "capacity",
	TYPE: "type",
	INSTRUCTOR_ID: "instructor_id",
};

const CLIENTS_CLASSES_TABLE = {
	CLASS_ID: "class_id",
	CLIENT_ID: "client_id",
};

module.exports = {
	CLIENTS,
	INSTRUCTORS,
	FITNESS_CLASSES,
	CLIENTS_CLASSES,
	CLIENTS_TABLE,
	INSTRUCTORS_TABLE,
	FITNESS_CLASSES_TABLE,
	CLIENTS_CLASSES_TABLE,
};
