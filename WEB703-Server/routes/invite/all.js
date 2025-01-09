//SETUP - Modules
var express = require('express');
var router = express.Router();


//SETUP - Import Models
const Group = require('../../models/group')
const Invitation = require('../../models/invitation')


//SETUP - Import Middlewares
const authorize = require('../../middlewares/auth')


/* -------------------------------------------------------------------------- */
/*                     //SECTION - Get Invitations                            */
/* -------------------------------------------------------------------------- */
router.get(
    '/all',
    authorize(['admin', 'user']),
    async (req, res, next) => {
        try {
            // Get the user ID from the session
            const userId = req.session.user._id;

            // Find the groups the user belongs to
            const groups = await Group.find({ users: userId });

            // Initialize an array to hold all invitations
            let invitations = [];

            // Loop through each group and get the invitations
            for (const group of groups) {
                const groupInvitations = await Invitation.find({ group: group._id });
                invitations = invitations.concat(groupInvitations);
            }

            // Return the invitations
            return res.status(200).json({
                invitations,
            });
        } catch (error) {
            // If there's an error, respond with a server error.
            console.log(error);
            return res.status(500).json({
                error: "Something went wrong on our end. Please try again.",
            });
        }
    }
);

module.exports = router;