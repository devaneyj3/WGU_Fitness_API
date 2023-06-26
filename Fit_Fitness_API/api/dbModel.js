const {
	FITNESS_CLASSES_TABLE,
	FITNESS_CLASSES,
	CLIENTS_CLASSES,
} = require("../contants");
const db = require("../data/db.config");

module.exports = {
	getFromDB,
	addData,
	clearDatabase,
	find,
	findByID,
	deleteByID,
	edit,
	getIdClasses,
	instructorPostClasses,
	editClasses,
	addClassToClient,
	incrementClassAttendees,
};

//reusable get function to retreive data from all databases
function getFromDB(dbName) {
	return db(dbName);
}

//POST data to the database
function addData(text, object) {
	console.log("inserting data", object);
	return db(text).insert(object);
}

function find(name, object) {
	return db(name).where({ username: object }).first();
}
function findByID(name, id) {
	return db(name).where({ id: id }).first();
}
function deleteByID(name, id) {
	console.log(id);
	return db(name).where({ id: id }).del();
}
function edit(name, id, username, password) {
	const data = db(name)
		.where({ id: id })
		.update({ username: username, password: password });
	return data;
}

function getIdClasses(text, id) {
	if (text === "instructors") {
		return db("instructors as i")
			.join("fitness_classes as c", "i.id", `c.instructor_id`)
			.select(
				"c.id",
				"c.name",
				"c.location",
				"c.details",
				"c.instructorname",
				"c.instructoremail",
				"c.instructorphone",
				"c.start_time",
				"c.end_time",
				"c.enrollment",
				"c.capacity"
			)
			.where("c.instructor_id", id);
	} else {
		return db("clients as c")
			.join("clients_classes as cc", "cc.client_id", "c.id")
			.join("fitness_classes as cl", "cc.class_id", "cl.id")
			.select(
				"cl.id",
				"cl.name",
				"cl.location",
				"cl.details",
				"cl.instructorname",
				"cl.instructoremail",
				"cl.instructorphone",
				"cl.start_time",
				"cl.end_time",
				"cl.enrollment",
				"cl.capacity",
				"cl.type"
			)
			.where("cc.client_id", id);
	}
}

//instructor can post classes that they teach
function instructorPostClasses(object, id) {
	console.log("instructorPostClasses, ", object);
	return db(FITNESS_CLASSES).insert(object).where({ id: id });
}

function editClasses(
	id,
	name,
	details,
	start_time,
	end_time,
	location,
	enrollment,
	capacity,
	type
) {
	const data = db(FITNESS_CLASSES_TABLE).where({ id: id }).update({
		name,
		details,
		location,
		start_time,
		end_time,
		enrollment,
		capacity,
		type,
	});
	return data;
}

function addClassToClient(id, clasID) {
	return db(CLIENTS_CLASSES).insert({ client_id: id, class_id: clasID });
}

function incrementClassAttendees(id) {
	return db(FITNESS_CLASSES)
		.where({ id: id })
		.increment(FITNESS_CLASSES_TABLE.ENROLLMENT, 1);
}

function clearDatabase(text) {
	return db(text).truncate();
}
