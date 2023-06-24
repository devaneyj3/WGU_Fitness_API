const jwt = require("jsonwebtoken");
const secrets = require("./config");
const bcrypt = require("bcryptjs");

module.exports = {
	dbError,
	notFound,
	generateToken,
	hashPassword,
};

function dbError(res) {
	return res.status(500).json({ message: res.message });
}

function notFound(text, res) {
	return res.status(404).json({ message: `There are no ${text}` });
}

async function hashPassword(req) {
	const hashedPassword = await bcrypt.hashSync(req.body.password, 10);
	req.body.password = hashedPassword;
	return req.body.password;
}

function generateToken(user, title) {
	const payload = {
		subject: user.id,
		username: user.username,
		role: title,
	};
	const config = {
		expiresIn: "1hr",
	};
	return jwt.sign(payload, secrets.jwtSecret, config);
}
