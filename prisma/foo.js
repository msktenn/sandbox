export default async (req, res) => {
  await firebase
    .firestore()
    .collection("contacts")
    .where("work_email", "==", req.body)
    .limit(1)
    .get()
    .then((querySnapshot) => {
      if (!querySnapshot.empty) {
        const queryDocumentSnapshot = querySnapshot.docs[0];
        var json = JSON.stringify(queryDocumentSnapshot);
        console.log(json);
        queryDocumentSnapshot
          .delete()
          .then(function () {
            console.log("Successfully deleted contact");
          })
          .catch(function (error) {
            console.log("Error deleting contact:", error);
          });
      } else {
        console.log("No document corresponding to the query!");
        return null;
      }
    });

  const user = await auth.getUserByEmail(req.body);
  if (!user.empty) {
    admin
      .auth()
      .deleteUser(user.toJSON().uid)
      .then(function () {
        console.log("Successfully deleted user");
      })
      .catch(function (error) {
        console.log("Error deleting user:", error);
      });
  }
  res.status(200).json({ status: "OK" });
};
