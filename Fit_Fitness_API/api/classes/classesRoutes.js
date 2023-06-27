const express = require("express");

const routes = express.Router();

const db = require("../dbModel");

const helper = require("../helper");

const endPoint = require("../endPoints");

const mw = require("../middleware");
const { FITNESS_CLASSES } = require("../../contants");

routes.get("/", async (req, res) => {
	const classes = await db.getFromDB(FITNESS_CLASSES);
	console.log("getting classes", classes);
	try {
		if (classes) {
			res.status(200).send(classes);
		} else {
			helper.notFound("classes", res);
		}
	} catch (error) {
		helper.dbError(res);
	}
});

routes.get("/:id", (req, res) => {
	endPoint.findUser(FITNESS_CLASSES, req, res);
});

routes.delete("/:id", (req, res) => {
	endPoint.deleteData(FITNESS_CLASSES, req, res);
});

routes.put("/:id", (req, res) => {
	endPoint.editData(FITNESS_CLASSES, req, res);
});
routes.put("/:id/updateAttendees", (req, res) => {
	endPoint.incrementAttendees(FITNESS_CLASSES, req, res);
});

routes.put("/:id/decrementAttendees", (req, res) => {
	endPoint.decrementAttendees(FITNESS_CLASSES, req, res);
});

module.exports = routes;
