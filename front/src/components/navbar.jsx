import { useState } from "react";
import { useRouter } from "next/router";

import Menu from "@mui/material/Menu";
import MenuItem from "@mui/material/MenuItem";
import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import IconButton from "@mui/material/IconButton";
import MenuIcon from "@mui/icons-material/Menu";

import "@/app/globals.css";
import ShareableLinkModal from "./modal/link/shareable-link-modal";
import BoardWithoutAuthenticationService from "../services/requests/board-without-authentication-service";

function Navbar({ projectName, showMenu, projectId }) {
  const [anchorEl, setAnchorEl] = useState(null);
  const [openModal, setOpenModal] = useState(false);
  const [url, setUrl] = useState("");
  const openMenu = Boolean(anchorEl);
  const router = useRouter();
  
  const handleOpenMenuButtons = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleCloseMenu = () => {
    setAnchorEl(null);
  };

  const handleOpenShareableLinkModal = async () => {
    const url = await BoardWithoutAuthenticationService.createLink(projectId);
    setUrl(url);
    setAnchorEl(null);
    setOpenModal(true); 
  };

  const handleCloseShareableLinkModal = () => {
    setOpenModal(false);
  };

  return (
    <>
      <ShareableLinkModal
        open={openModal}
        url={url}
        setOpen={handleCloseShareableLinkModal}
      />
      <AppBar style={{ background: "#1C1C1C", position: "relative" }}>
        <Toolbar variant="dense">
          {showMenu && (
            <div>
              <IconButton
                edge="start"
                color="inherit"
                aria-label="menu"
                sx={{ mr: 2 }}
                onClick={handleOpenMenuButtons}
              >
                <MenuIcon />
              </IconButton>

              <Menu anchorEl={anchorEl} open={openMenu} onClose={handleCloseMenu}>
                <MenuItem onClick={() => router.push("/projects")}>
                  Novo Projeto
                </MenuItem>

                <MenuItem onClick={() => router.push("/projects")}>
                  Ver Projetos
                </MenuItem>
                <MenuItem onClick={handleOpenShareableLinkModal}>Criar Link</MenuItem>
              </Menu>
            </div>
          )}
          <label
            style={{
              fontFamily: "Roboto Mono, monospace",
              fontWeight: 600,
              fontSize: "20px",
            }}
          >
            {projectName}
          </label>
        </Toolbar>
      </AppBar>
    </>
  );
}

export default Navbar;
