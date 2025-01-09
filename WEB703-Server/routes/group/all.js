//SETUP - Modules
var express = require('express');
var router = express.Router();


//SETUP - Import Models
const Group = require('../../models/group')
const User = require('../../models/user')


//SETUP - Import Middlewares
const authorize = require('../../middlewares/auth')


/* -------------------------------------------------------------------------- */
/*                     //SECTION - Get Groups of a user                       */
/* -------------------------------------------------------------------------- */
router.get(
    '/all',
    authorize(['admin', 'user']),
    async (req, res, next) => {
        try {
            // Get the user ID from the session.
            const userId = req.session.user._id;

            // Find the user in the database.
            const user = await User.findById(userId);

            // If the user doesn't exist, respond with a 404 error.
            if (!user) {
                return res.status(404).json({ error: 'User not found' });
            }

            let groups;
            
            // If the user is an admin, get all groups.
            if (user.role === 'admin') {
                groups = await Group.find();
            } else {
                // Else the user is not an admin, get the groups the user is in.
                groups = await Group.find({ users: userId });
            }

            return res.json({ groups });

            
        } catch (error) {
            // If there's an error, respond with a server error.
            return res.status(500).json({ error: "Something went wrong on our end. Please try again. "});
        }
    }
);


module.exports = router;