require("dotenv").config();

let express = require("express");
let cors = require("cors");
let logger = require("morgan");
let helmet = require("helmet");

let classesRoute = require("./api/classes/classesRoutes");
let clientsRoute = require("./api/clients/clientsRoute");
let instructorsRoute = require("./api/instructors/instructorsRoute");

let app = express();

app.use(logger("dev"));
app.use(express.json());
app.use(cors());
app.use(helmet());

app.use("/api/fitness_classes", classesRoute);
app.use("/api/clients", clientsRoute);
app.use("/api/instructors", instructorsRoute);

app.get("/", function (req, res) {
	res.status(200).send("app is up");
});

const port = process.env.PORT || 3000; // Use the PORT environment variable if available, otherwise use port 3000

app.listen(port, () => {
	console.log(`Server listening on port ${port}`);
});
