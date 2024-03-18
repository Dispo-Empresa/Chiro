"use client";

import { useState } from "react";
import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import IconButton from "@mui/material/IconButton";
import AddIcon from "@mui/icons-material/Add";
import MenuIcon from "@mui/icons-material/Menu";
import Box from "@mui/material/Box";
import Modal from "@mui/material/Modal";
import Bubble from "@/components/bubble/bubble";
import { Grid } from "@mui/material";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";

import "../app/globals.css";
import ClassicButton from "@/components/ui/buttons";

function ProjectBoard() {
  const containerStyle = {
    display: "flex",
    flexDirection: "column",
    height: "100vh",
  };

  const rowStyle = {
    display: "flex",
    flex: 1,
    border: "1px solid white",
  };

  const topRowStyle = {
    ...rowStyle,
    position: "relative",
    display: "block",
    flex: 1,
  };

  const middleRowStyle = {
    ...rowStyle,
    flex: 0.05,
  };

  const bottomRowStyle = {
    ...rowStyle,
  };

  const addButtonStyle = {
    margin: "0 30px",
    marginTop: "30px",
    padding: "25px",
    borderRadius: "50%",
    backgroundColor: "#2196f3",
    color: "#fff",
  };

  const styleModal = {
    position: "absolute",
    top: "50%",
    left: "50%",
    transform: "translate(-50%, -50%)",
    width: 380,
    bgcolor: "background.paper",
    color: "#1F1F1F",
    border: "2px solid #000",
    boxShadow: 24,
    p: 4,
    padding: "30px 20px 30px 30px",
    borderRadius: "10px",
  };

  const [bubbles, setBubbles] = useState([]);
  const [selectedBubble, setSelectedBubble] = useState(null);
  const [isBubbleInRow, setIsBubbleInRow] = useState(false);
  const [open, setOpen] = useState(false);
  const [startDate, setStartDate] = useState(null);
  const [endDate, setEndDate] = useState(null);

  const handleOpen = () => setOpen(true);

  const addBox = () => {
    // y = vertical
    // x = horizontal

    setBubbles((prevbubbles) => [
      ...prevbubbles,
      {
        id: new Date().getTime(),
        x: 300,
        y: 20,
        width: 190,
        height: 91,
      },
    ]);
  };

  const onBubbleDragStop = (id, x, y) => {
    const rowDiv = document.getElementById("bottomRowStyle");
    if (rowDiv) {
      const rowRect = rowDiv.getBoundingClientRect();
      const buffer = 65;
      if (
        x >= rowRect.left - buffer &&
        x <= rowRect.right + buffer &&
        y >= rowRect.top - buffer &&
        y <= rowRect.bottom + buffer
      ) {
        setIsBubbleInRow(true);
        handleOpen();
        setSelectedBubble(id);
      } else {
        setIsBubbleInRow(false);
      }
    }
  };

  const handleSubmit = () => {
    const options = { year: "numeric", month: "2-digit", day: "2-digit" };

    console.log(
      `Atividade ${selectedBubble} definida para começar ${new Date(
        startDate
      ).toLocaleDateString("pt-BR", options)} e terminar ${new Date(
        endDate
      ).toLocaleDateString("pt-BR", options)}`
    );
    handleClose();
  };

  const handleClose = () => {
    setOpen(false);

    // Caso houver o cancelamento da data, a bubble deve voltar para onde estava no board de cima

    //if (!startDate || !endDate) {
    //  setBubbles((prevBubbles) => {
    //    const index = prevBubbles.findIndex(
    //      (bubble) => bubble.id === selectedBubble
    //    );
    //
    //    if (index === -1) return prevBubbles;
    //
    //    const updatedBubbles = [...prevBubbles];
    //
    //    updatedBubbles[index] = {
    //      ...updatedBubbles[index],
    //      x: 300,
    //      y: 20,
    //    };
    //
    //    return updatedBubbles;
    //  });
    //}
  };

  const ModalComponente = () => {
    return (
      <Modal keepMounted open={open} onClose={handleClose}>
        <Box sx={styleModal}>
          <LocalizationProvider dateAdapter={AdapterDayjs}>
            <Grid container spacing={6} columns={16}>
              <Grid item xs={8}>
                <label
                  style={{
                    fontSize: "15px",
                    fontWeight: "500",
                  }}
                >
                  Data Início
                </label>
                <DatePicker
                  sx={{ marginTop: "5px" }}
                  slotProps={{ textField: { variant: "standard" } }}
                  format="DD/MM/YYYY"
                  value={startDate}
                  onChange={(value) => setStartDate(value)}
                />
              </Grid>
              <Grid item xs={8}>
                <label style={{ fontSize: "15px", fontWeight: "500" }}>
                  Data Término
                </label>
                <DatePicker
                  sx={{ marginTop: "5px" }}
                  slotProps={{ textField: { variant: "standard" } }}
                  format="DD/MM/YYYY"
                  value={endDate}
                  onChange={(value) => setEndDate(value)}
                />
              </Grid>
            </Grid>
          </LocalizationProvider>
          <div
            style={{
              display: "flex",
              alignItems: "center",
              justifyContent: "center",
              marginTop: "30px",
            }}
          >
            <ClassicButton onClick={handleSubmit} title="Confirmar" />
          </div>
        </Box>
      </Modal>
    );
  };

  return (
    <div style={containerStyle}>
      <AppBar position="static">
        <Toolbar>
          <IconButton edge="start" color="inherit" aria-label="menu">
            <MenuIcon />
          </IconButton>
        </Toolbar>
      </AppBar>
      <div style={topRowStyle}>
        <ModalComponente />
        <IconButton style={addButtonStyle} onClick={addBox}>
          <AddIcon />
        </IconButton>
        {bubbles.map((box) => (
          <Bubble
            key={box.id}
            box={box}
            boxes={bubbles}
            setBoxes={setBubbles}
            onDragStop={onBubbleDragStop}
          />
        ))}
      </div>
      {/* 
      <div style={middleRowStyle}>
        <Timeline 
      </div>
        */}
      <div id="bottomRowStyle" style={bottomRowStyle}></div>
    </div>
  );
}

export default ProjectBoard;