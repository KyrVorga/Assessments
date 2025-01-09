//SETUP - Modules
var express = require('express');
var router = express.Router();


//SETUP - Import Models
const Group = require('../../models/group')
const Invitation = require('../../models/invitation')


//SETUP - Import Middlewares
const { handleValidationErrors, codeSchema, validate } = require('../../middlewares/validation');
const { checkSchema } = require('express-validator');
const authorize = require('../../middlewares/auth')




/* -------------------------------------------------------------------------- */
/*                     //SECTION - Redeem Invitation                          */
/* -------------------------------------------------------------------------- */
router.post(
    '/redeem/:code',
    authorize(['admin', 'user']),
    validate(checkSchema(codeSchema)),
    handleValidationErrors,
    async (req, res, next) =>{
        try {    
            // Get the code from the request parameters
            const code = req.params.code;

            // Check if invitation exists in the database
            const existingInvitation = await
                Invitation.findOne({
                    code,
                });

            // Check for invitation in the database, if not found return an error code 404.
            if (!existingInvitation) {
                return res.status(404).json({
                    error: `Invitation with the code ${code} not found.`,
                });
            }

            // Check if the invitation is active
            if (existingInvitation.status !== 'active') {
                return res.status(409).json({
                    error: `Invitation with the code ${code} is expired.`,
                });
            }

            // Check if the invitation has expired
            if (existingInvitation.expiryDate < Date.now()) {
                return res.status(409).json({
                    error: `Invitation with the code ${code} has expired.`,
                });
            }

            // Check if the invitation has reached the maximum number of uses
            if (existingInvitation.currentUses >= existingInvitation.maxUses) {
                return res.status(409).json({
                    error: `Invitation with the code ${code} has reached the maximum number of uses.`,
                });
            }

            // Increment the current uses of the invitation
            existingInvitation.currentUses++;

            // Add the user to the group
            const group = await
                Group.findOne({
                    _id: existingInvitation.group,
                });

            // Check for group in the database, if not found return an error code 404.
            if (!group) {
                return res.status(404).json({
                    error: `Group with the ID ${existingInvitation.group} not found.`,
                });
            }

            // Check that the user is not already in the group
            if (group.users.includes(req.session.user._id)) {
                return res.status(409).json({
                    error: `User is already a member of the group.`,
                });
            }

            // Add the user to the group
            group.users.push(req.session.user._id);

            // Save the group
            await group.save();

            // Save the invitation
            await existingInvitation.save();

            // Return a success response
            return res.status(200).json({
                message: `Invitation with the code ${code} redeemed successfully.`,
            });
        } catch (error){
            // If there's an error, respond with a server error.
            console.log(error);
            return res.status(500).json({
                error: "Something went wrong on our end. Please try again. ",
            });
        }
    }
);



module.exports = router;