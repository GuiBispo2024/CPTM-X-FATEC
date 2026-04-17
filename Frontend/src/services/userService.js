const API = "https://localhost:5001/api/users"; // ajusta porta

export async function getUsers() {
  const res = await fetch(API);
  return res.json();
}

export async function createUser(user) {
  const res = await fetch(API, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(user),
  });
  return res.json();
}

export async function updateUser(id, user) {
  await fetch(`${API}/${id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(user),
  });
}

export async function deleteUser(id) {
  await fetch(`${API}/${id}`, {
    method: "DELETE",
  });
}