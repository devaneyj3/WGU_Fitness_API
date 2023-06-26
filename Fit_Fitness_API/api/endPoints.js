const db = require("./dbModel");

const helper = require("./helper");

const bcrypt = require("bcryptjs");

module.exports = {
	getEndPoint,
	register,
	login,
	findUser,
	deleteData,
	editData,
	getClassesByID,
	instructorsNewClasses,
	addClientClass,
	incrementAttendees,
};

async function getEndPoint(text, res) {
	const data = await db.getFromDB(text);
	console.log(data);
	try {
		if (data) {
			res.status(200).send(data);
		} else {
			helper.notFound(text, res);
		}
	} catch (error) {
		helper.dbError(res);
	}
}

async function register(text, req, res) {
	const hashPassword = await helper.hashPassword(req);
	req.body.password = hashPassword;
	try {
		await db.addData(text, req.body);
		res.status(201).send(req.body);
	} catch {
		helper.dbError(res);
	}
}

async function login(text, req, res) {
	const { password, username } = req.body;
	const user = await db.find(text, username);
	try {
		if (user && bcrypt.compareSync(password, user.password)) {
			const title = text === "clients" ? "client" : "instructor";
			const token = helper.generateToken(user, title);

			res.status(200).json({
				name: user.username,
				message: ` Welcome ${user.username} `,
				username: user.username,
				email: user.email,
				phone: user.phone,
				id: user.id,
				token,
			});
		} else {
			res.status(404).json({ message: `${username}, could not be found` });
		}
	} catch {
		helper.dbError(res);
	}
}
async function findUser(text, req, res) {
	const { id } = req.params;
	const user = await db.findByID(text, id);
	try {
		if (user) {
			res.status(200).send(user);
		} else {
			helper.notFound(text, res);
		}
	} catch {
		helper.dbError(res);
	}
}
async function deleteData(text, req, res) {
	const { id } = req.params;
	const user = await db.deleteByID(text, id);
	console.log("deleting id");
	try {
		if (user) {
			res.status(200).send(id);
		} else {
			helper.notFound(text, res);
		}
	} catch {
		helper.dbError(res);
	}
}
async function editData(text, req, res, name) {
	const { id } = req.params;
	if (text === "instructors" || text === "clients") {
		const password = await helper.hashPassword(req);
		let data = await db.edit(text, id, req.body.username, password);
		try {
			if (data) {
				res.status(200).json({ message: `Changed ID: ${id}` });
			} else {
				helper.notFound(text, res);
			}
		} catch {
			helper.dbError(res);
		}
	} else {
		let data = await db.editClasses(
			id,
			req.body.name,
			req.body.type,
			req.body.startTime,
			req.body.duration,
			req.body.intensityLevel,
			req.body.location,
			req.body.attendees,
			req.body.maxClassSize
		);
		try {
			if (data) {
				res.status(200).json({ message: `Changed ID: ${id}` });
			} else {
				helper.notFound(text, res);
			}
		} catch {
			helper.dbError(res);
		}
	}
}

async function getClassesByID(text, req, res) {
	const { id } = req.params;
	const classes = await db.getIdClasses(text, id);
	try {
		if (classes) {
			res.status(200).send(classes);
		} else {
			helper.notFound(text, res);
		}
	} catch {
		helper.dbError(res);
	}
}
async function instructorsNewClasses(text, req, res) {
	const { id } = req.params;
	console.log(id, req.body);
	const classes = await db.instructorPostClasses(req.body, id);
	try {
		if (classes) {
			res.status(200).send(req.body);
		} else {
			helper.notFound(text, res);
		}
	} catch {
		helper.dbError(res);
	}
}
async function addClientClass(req, res) {
	const { id } = req.params;
	const { classID } = req.params;
	const classes = await db.addClassToClient(id, classID);
	console.log(classes);
	try {
		if (classes) {
			res
				.status(200)
				.send({ message: `Class ID: ${classID} successfully added` });
		} else {
			helper.notFound(text, res);
		}
	} catch {
		helper.dbError(res);
	}
}

async function incrementAttendees(text, req, res) {
	const { id } = req.params;
	const data = await db.incrementClassAttendees(id);
	try {
		if (data) {
			res.status(200).send(id);
		} else {
			helper.notFound(text, res);
		}
	} catch {
		helper.dbError(res);
	}
}
