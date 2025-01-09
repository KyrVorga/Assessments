//SETUP - Modules
var express = require("express");
var router = express.Router();


//SETUP - Import Models
const Group = require("../../models/group");
const User = require("../../models/user");


//SETUP - Import Middlewares
const { validate, handleValidationErrors, groupSchema } = require("../../middlewares/validation");
const { matchedData, checkSchema } = require("express-validator");
const authorize = require('../../middlewares/auth')


/* -------------------------------------------------------------------------- */
/*                          //SECTION - Create Group                          */
/* -------------------------------------------------------------------------- */
router.post(
    "/create",
    authorize(['admin', 'user']),
    validate(checkSchema(groupSchema)),
    handleValidationErrors,
    async (req, res, next) => {
        try {
            // Extract data from the validated data.
            const data = matchedData(req);
            const {
                name,
            } = data;

            // Check if group already exists in the database
            const existingGroup = await
                Group.findOne({
                    name,
                });

            // Check for group in the database, if found return an error code 409.
            if (existingGroup) {
                return res.status(409).json({
                    error: `Group with the name ${name} already exists.`,
                });
            }

            // Get the user from the request
            const user = await User.findById(req.session.user._id);

            // Create the group
            const newGroup = new Group({
                name
            });

            // Add the user to the group
            newGroup.users.push(user._id);

            // Save the group and get the id
            const group = await newGroup.save();

            // Add the group to the user's groups
            user.groups.push(group._id);

            // Save the user
            await user.save();

            // Return a success response
            return res.status(201).json({
                message: `Group ${name} created successfully.`,
                group,
            });
        } catch (error) {
            // If there's an error, respond with a server error.
            console.log(error);
            return res.status(500).json({
                error: "Something went wrong on our end. Please try again. ",
            });
        }
    }
);

module.exports = router;
